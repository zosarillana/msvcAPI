using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMarketVisitSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Pods_pod_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits",
                column: "area_id",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits",
                column: "pap_id",
                principalTable: "Paps",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Pods_pod_id",
                table: "MarketVisits",
                column: "pod_id",
                principalTable: "Pods",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "Role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_MarketVisits_Pods_pod_id",
                table: "MarketVisits");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_role_id",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Areas_area_id",
                table: "MarketVisits",
                column: "area_id",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Paps_pap_id",
                table: "MarketVisits",
                column: "pap_id",
                principalTable: "Paps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarketVisits_Pods_pod_id",
                table: "MarketVisits",
                column: "pod_id",
                principalTable: "Pods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
