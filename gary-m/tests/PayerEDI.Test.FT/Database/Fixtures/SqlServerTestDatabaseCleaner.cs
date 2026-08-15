using Microsoft.Data.SqlClient;

namespace PayerEDI.Test.FT.Database.Fixtures;

internal static class SqlServerTestDatabaseCleaner
{
    private const string MigrationHistoryTable = "__EFMigrationsHistory";

    public static async Task CleanAsync(SqlConnection connection)
    {
        var tables = await GetTablesAsync(connection);
        if (tables.Count == 0)
        {
            return;
        }

        var relationships = await GetRelationshipsAsync(connection, tables);
        var orderedTables = SortChildTablesFirst(tables, relationships);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            if (relationships.Count == 0)
            {
                foreach (var table in orderedTables)
                {
                    await ExecuteAsync(
                        connection,
                        transaction,
                        $"TRUNCATE TABLE {table.QualifiedName};"
                    );
                }
            }
            else
            {
                foreach (var table in orderedTables)
                {
                    await ExecuteAsync(
                        connection,
                        transaction,
                        $"ALTER TABLE {table.QualifiedName} NOCHECK CONSTRAINT ALL;"
                    );
                }

                foreach (var table in orderedTables)
                {
                    await ExecuteAsync(
                        connection,
                        transaction,
                        $"DELETE FROM {table.QualifiedName};"
                    );
                }

                foreach (var table in orderedTables)
                {
                    await ExecuteAsync(
                        connection,
                        transaction,
                        $"ALTER TABLE {table.QualifiedName} WITH CHECK CHECK CONSTRAINT ALL;"
                    );
                }
            }

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    private static async Task<List<Table>> GetTablesAsync(SqlConnection connection)
    {
        const string sql = """
            SELECT schemas.name, tables.name
            FROM sys.tables AS tables
            INNER JOIN sys.schemas AS schemas ON schemas.schema_id = tables.schema_id
            WHERE tables.is_ms_shipped = 0 AND tables.name <> @migrationHistoryTable;
            """;

        await using var command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@migrationHistoryTable", MigrationHistoryTable);
        await using var reader = await command.ExecuteReaderAsync();
        var tables = new List<Table>();

        while (await reader.ReadAsync())
        {
            tables.Add(new Table(reader.GetString(0), reader.GetString(1)));
        }

        return tables;
    }

    private static async Task<List<Relationship>> GetRelationshipsAsync(
        SqlConnection connection,
        IReadOnlyCollection<Table> tables
    )
    {
        const string sql = """
            SELECT parentSchemas.name, parentTables.name, referencedSchemas.name, referencedTables.name
            FROM sys.foreign_keys AS foreignKeys
            INNER JOIN sys.tables AS parentTables ON parentTables.object_id = foreignKeys.parent_object_id
            INNER JOIN sys.schemas AS parentSchemas ON parentSchemas.schema_id = parentTables.schema_id
            INNER JOIN sys.tables AS referencedTables ON referencedTables.object_id = foreignKeys.referenced_object_id
            INNER JOIN sys.schemas AS referencedSchemas ON referencedSchemas.schema_id = referencedTables.schema_id;
            """;

        var knownTables = tables.ToHashSet();
        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();
        var relationships = new List<Relationship>();

        while (await reader.ReadAsync())
        {
            var child = new Table(reader.GetString(0), reader.GetString(1));
            var parent = new Table(reader.GetString(2), reader.GetString(3));
            if (knownTables.Contains(child) && knownTables.Contains(parent))
            {
                relationships.Add(new Relationship(child, parent));
            }
        }

        return relationships;
    }

    private static IReadOnlyList<Table> SortChildTablesFirst(
        IReadOnlyCollection<Table> tables,
        IReadOnlyCollection<Relationship> relationships
    )
    {
        var remaining = tables.ToHashSet();
        var ordered = new List<Table>();

        while (remaining.Count > 0)
        {
            var leafTables = remaining
                .Where(table =>
                    relationships.All(relationship =>
                        relationship.Child != table || !remaining.Contains(relationship.Parent)
                    )
                )
                .ToList();

            if (leafTables.Count == 0)
            {
                ordered.AddRange(remaining.OrderBy(table => table.QualifiedName));
                break;
            }

            ordered.AddRange(leafTables.OrderBy(table => table.QualifiedName));
            foreach (var table in leafTables)
            {
                remaining.Remove(table);
            }
        }

        return ordered;
    }

    private static async Task ExecuteAsync(
        SqlConnection connection,
        SqlTransaction transaction,
        string sql
    )
    {
        await using var command = new SqlCommand(sql, connection, transaction);
        await command.ExecuteNonQueryAsync();
    }

    private sealed record Table(string Schema, string Name)
    {
        public string QualifiedName => $"{Quote(Schema)}.{Quote(Name)}";

        private static string Quote(string value) =>
            $"[{value.Replace("]", "]]", StringComparison.Ordinal)}]";
    }

    private sealed record Relationship(Table Child, Table Parent);
}
