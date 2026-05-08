using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace X12EDI837.Ingestion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterchangeControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionSetControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TotalChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacilityTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentOfBenefits = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseOfInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ServiceDateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IngestedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceFileName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillingProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    Npi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxonomyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillingProviders_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosisCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    Qualifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiagnosisCodes_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    ProcedureCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifier1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modifier2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    DiagnosisCodePointer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceLines_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnipValidationErrors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    SnipLevel = table.Column<int>(type: "int", nullable: false),
                    Segment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegmentPosition = table.Column<int>(type: "int", nullable: true),
                    RecordedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnipValidationErrors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnipValidationErrors_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingProviders_ClaimId",
                table: "BillingProviders",
                column: "ClaimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Claims_ClaimId",
                table: "Claims",
                column: "ClaimId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisCodes_ClaimId",
                table: "DiagnosisCodes",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceLines_ClaimId",
                table: "ServiceLines",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_SnipValidationErrors_ClaimId",
                table: "SnipValidationErrors",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_ClaimId",
                table: "Subscribers",
                column: "ClaimId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillingProviders");

            migrationBuilder.DropTable(
                name: "DiagnosisCodes");

            migrationBuilder.DropTable(
                name: "ServiceLines");

            migrationBuilder.DropTable(
                name: "SnipValidationErrors");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
