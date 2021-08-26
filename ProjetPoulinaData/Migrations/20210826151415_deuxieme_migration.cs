using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetPoulinaData.Migrations
{
    public partial class deuxieme_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "fk_speculation_centre",
                table: "stock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_stock_fk_speculation_centre",
                table: "stock",
                column: "fk_speculation_centre");

            migrationBuilder.AddForeignKey(
                name: "FK_stock_speculation_centre_fk_speculation_centre",
                table: "stock",
                column: "fk_speculation_centre",
                principalTable: "speculation_centre",
                principalColumn: "speculation_centre_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stock_speculation_centre_fk_speculation_centre",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_fk_speculation_centre",
                table: "stock");

            migrationBuilder.DropColumn(
                name: "fk_speculation_centre",
                table: "stock");
        }
    }
}
