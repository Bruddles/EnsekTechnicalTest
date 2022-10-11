using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsekTechnicalTest.Database.Migrations
{
    public partial class AddingSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "AccountId1", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1234, null, "Freya", "Test" },
                    { 1239, null, "Noddy", "Test" },
                    { 1240, null, "Archie", "Test" },
                    { 1241, null, "Lara", "Test" },
                    { 1242, null, "Tim", "Test" },
                    { 1243, null, "Graham", "Test" },
                    { 1244, null, "Tony", "Test" },
                    { 1245, null, "Neville", "Test" },
                    { 1246, null, "Jo", "Test" },
                    { 1247, null, "Jim", "Test" },
                    { 1248, null, "Pam", "Test" },
                    { 2233, null, "Barry", "Test" },
                    { 2344, null, "Tommy", "Test" },
                    { 2345, null, "Jerry", "Test" },
                    { 2346, null, "Ollie", "Test" },
                    { 2347, null, "Tara", "Test" },
                    { 2348, null, "Tammy", "Test" },
                    { 2349, null, "Simon", "Test" },
                    { 2350, null, "Colin", "Test" },
                    { 2351, null, "Gladys", "Test" },
                    { 2352, null, "Greg", "Test" },
                    { 2353, null, "Tony", "Test" },
                    { 2355, null, "Arthur", "Test" },
                    { 2356, null, "Craig", "Test" },
                    { 4534, null, "JOSH", "TEST" },
                    { 6776, null, "Laura", "Test" },
                    { 8766, null, "Sally", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2233);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2344);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2345);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2346);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2347);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2348);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2349);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2350);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2351);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2352);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2353);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2355);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2356);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4534);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 6776);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 8766);
        }
    }
}
