using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekTechnicalTest.Database.Migrations
{
    public partial class AddingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccountId1",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings",
                column: "AccountId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_AccountId1",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_MeterReadings_Accounts_AccountId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_MeterReadings_AccountId",
                table: "MeterReadings");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AccountId1",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "Accounts");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
