using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_account_role_tb_role_RoleId",
                table: "tb_account_role");

            migrationBuilder.DropIndex(
                name: "IX_tb_account_role_RoleId",
                table: "tb_account_role");

            migrationBuilder.DropColumn(
                name: "NIK",
                table: "tb_account_role");

            migrationBuilder.DropColumn(
                name: "Role_Id",
                table: "tb_account_role");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "tb_account_role",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "tb_account_role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_role_RoleId1",
                table: "tb_account_role",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_account_role_tb_role_RoleId1",
                table: "tb_account_role",
                column: "RoleId1",
                principalTable: "tb_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_account_role_tb_role_RoleId1",
                table: "tb_account_role");

            migrationBuilder.DropIndex(
                name: "IX_tb_account_role_RoleId1",
                table: "tb_account_role");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "tb_account_role");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "tb_account_role",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIK",
                table: "tb_account_role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role_Id",
                table: "tb_account_role",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_account_role_RoleId",
                table: "tb_account_role",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_account_role_tb_role_RoleId",
                table: "tb_account_role",
                column: "RoleId",
                principalTable: "tb_role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
