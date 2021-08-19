using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetPoulinaData.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "amortissement",
                columns: table => new
                {
                    AmortissementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateDu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Prix = table.Column<float>(type: "real", nullable: false),
                    TotalAmortissement = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortissement", x => x.AmortissementId);
                });

            migrationBuilder.CreateTable(
                name: "speculation",
                columns: table => new
                {
                    SpeculationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Delai = table.Column<float>(type: "real", nullable: false),
                    fk_centre = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speculation", x => x.SpeculationId);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValeurDuStock = table.Column<float>(type: "real", nullable: false),
                    DateDu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateAu = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "centre",
                columns: table => new
                {
                    CentreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Delai = table.Column<float>(type: "real", nullable: false),
                    fk_amortissement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_speculation = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centre", x => x.CentreId);
                    table.ForeignKey(
                        name: "FK_centre_amortissement_fk_amortissement",
                        column: x => x.fk_amortissement,
                        principalTable: "amortissement",
                        principalColumn: "AmortissementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prix",
                columns: table => new
                {
                    PrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prixx = table.Column<float>(type: "real", nullable: false),
                    fk_Speculation = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prix", x => x.PrixId);
                    table.ForeignKey(
                        name: "FK_prix_speculation_fk_Speculation",
                        column: x => x.fk_Speculation,
                        principalTable: "speculation",
                        principalColumn: "SpeculationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "traitementstock",
                columns: table => new
                {
                    TraitementStockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cout = table.Column<float>(type: "real", nullable: false),
                    Amortissement = table.Column<float>(type: "real", nullable: false),
                    ValeurResiduel = table.Column<float>(type: "real", nullable: false),
                    EffectifRestant = table.Column<int>(type: "int", nullable: false),
                    fk_stock = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_traitementstock", x => x.TraitementStockId);
                    table.ForeignKey(
                        name: "FK_traitementstock_stock_fk_stock",
                        column: x => x.fk_stock,
                        principalTable: "stock",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "speculation_centre",
                columns: table => new
                {
                    speculation_centre_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_centre = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fk_speculation = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speculation_centre", x => x.speculation_centre_Id);
                    table.ForeignKey(
                        name: "FK_speculation_centre_centre_fk_centre",
                        column: x => x.fk_centre,
                        principalTable: "centre",
                        principalColumn: "CentreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_speculation_centre_speculation_fk_speculation",
                        column: x => x.fk_speculation,
                        principalTable: "speculation",
                        principalColumn: "SpeculationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_centre_fk_amortissement",
                table: "centre",
                column: "fk_amortissement");

            migrationBuilder.CreateIndex(
                name: "IX_prix_fk_Speculation",
                table: "prix",
                column: "fk_Speculation");

            migrationBuilder.CreateIndex(
                name: "IX_speculation_centre_fk_centre",
                table: "speculation_centre",
                column: "fk_centre");

            migrationBuilder.CreateIndex(
                name: "IX_speculation_centre_fk_speculation",
                table: "speculation_centre",
                column: "fk_speculation");

            migrationBuilder.CreateIndex(
                name: "IX_traitementstock_fk_stock",
                table: "traitementstock",
                column: "fk_stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prix");

            migrationBuilder.DropTable(
                name: "speculation_centre");

            migrationBuilder.DropTable(
                name: "traitementstock");

            migrationBuilder.DropTable(
                name: "centre");

            migrationBuilder.DropTable(
                name: "speculation");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "amortissement");
        }
    }
}
