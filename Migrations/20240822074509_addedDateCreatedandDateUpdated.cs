using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class addedDateCreatedandDateUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abfi_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contact_num = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email_add = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MarketVisits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    visit_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_accountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_distributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_salesPersonnel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_accountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_isr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_isrNeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_payolaSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_payolaMerchandiser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_averageOffTakePd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_podCanned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_podMPP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_competitorsCheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_pap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketVisits", x => x.id);
                    table.ForeignKey(
                        name: "FK_MarketVisits_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_user_id",
                table: "MarketVisits",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketVisits");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
