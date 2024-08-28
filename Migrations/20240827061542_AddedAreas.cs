using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedAreas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "visit_area",
                table: "MarketVisits");

            migrationBuilder.AddColumn<int>(
                name: "area_id",
                table: "MarketVisits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_area_id",
                table: "MarketVisits",
                column: "area_id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits",
                column: "area_id",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_MarketVisits_area_id",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "area_id",
                table: "MarketVisits");

            migrationBuilder.AddColumn<string>(
                name: "visit_area",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
