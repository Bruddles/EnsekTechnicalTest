using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekTechnicalTest.Database.Migrations
{
    public partial class FixingMeterReadType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeterReadValue",
                table: "MeterReadings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MeterReadValue",
                table: "MeterReadings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
