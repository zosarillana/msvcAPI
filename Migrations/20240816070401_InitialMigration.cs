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
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    abfi_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_abfi_id",
                table: "Users",
                column: "abfi_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
