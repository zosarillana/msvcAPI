using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class NewTableColumnsForMarketVisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "isr_needsOthers",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "isr_needs_ImgPath",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "isr_reqOthers",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "isr_req_ImgPath",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pap_others",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pod_canned_other",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pod_mpp_other",
                table: "MarketVisits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isr_needsOthers",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "isr_needs_ImgPath",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "isr_reqOthers",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "isr_req_ImgPath",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "pap_others",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "pod_canned_other",
                table: "MarketVisits");

            migrationBuilder.DropColumn(
                name: "pod_mpp_other",
                table: "MarketVisits");
        }
    }
}
