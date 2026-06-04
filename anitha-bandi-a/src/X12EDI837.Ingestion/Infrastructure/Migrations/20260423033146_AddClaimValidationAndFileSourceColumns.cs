using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X12EDI837.Ingestion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimValidationAndFileSourceColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileSource",
                table: "Claims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Claims",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SnipErrorCount",
                table: "Claims",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileSource",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Claims");

            migrationBuilder.DropColumn(
                name: "SnipErrorCount",
                table: "Claims");
        }
    }
}
