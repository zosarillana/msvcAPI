using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class RemovedVisitIsrNEed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "visit_isrNeed",
                table: "MarketVisits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "visit_isrNeed",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
