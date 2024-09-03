using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class NewPapForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "visit_pap",
                table: "MarketVisits");

            migrationBuilder.AddColumn<int>(
                name: "pap_id",
                table: "MarketVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Paps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pap_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pap_others = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paps", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_pap_id",
                table: "MarketVisits",
                column: "pap_id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits",
                column: "pap_id",
                principalTable: "Paps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits");

            migrationBuilder.DropTable(
                name: "Paps");

            migrationBuilder.DropIndex(
                name: "IX_MarketVisits_pap_id",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "pap_id",
                table: "MarketVisits");

            migrationBuilder.AddColumn<string>(
                name: "visit_pap",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
