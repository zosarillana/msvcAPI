using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Isrs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isr_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isr_others = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    isr_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isrs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pod_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pod_others = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pod_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    image_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                });

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
                    role_id = table.Column<int>(type: "int", maxLength: 50, nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Users_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    isr_id = table.Column<int>(type: "int", nullable: false),
                    visit_isrNeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_payolaSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_payolaMerchandiser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_averageOffTakePd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pod_id = table.Column<int>(type: "int", nullable: false),
                    visit_competitorsCheck = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    visit_pap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    date_updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketVisits", x => x.id);
                    table.ForeignKey(
                        name: "FK_MarketVisits_Isrs_isr_id",
                        column: x => x.isr_id,
                        principalTable: "Isrs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MarketVisits_Pods_pod_id",
                        column: x => x.pod_id,
                        principalTable: "Pods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketVisits_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_isr_id",
                table: "MarketVisits",
                column: "isr_id");

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_pod_id",
                table: "MarketVisits",
                column: "pod_id");

            migrationBuilder.CreateIndex(
                name: "IX_MarketVisits_user_id",
                table: "MarketVisits",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketVisits");

            migrationBuilder.DropTable(
                name: "Isrs");

            migrationBuilder.DropTable(
                name: "Pods");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
