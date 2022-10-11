using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekTechnicalTest.Database.Migrations
{
    public partial class FixingAccountFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_AccountId1",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountId1",
                table: "Accounts",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts_AccountId1",
                table: "Accounts",
                column: "AccountId1",
                principalTable: "Accounts",
                principalColumn: "AccountId");
        }
    }
}
