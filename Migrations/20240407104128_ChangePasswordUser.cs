using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soppi.Migrations
{
    public partial class ChangePasswordUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ecef19c-f5e6-43db-8733-6067836c341d", "AQAAAAEAACcQAAAAEDr3eNffVuz9zY4caFnnEUejTwQThV2sgrfs4Cz5gdcrkMegZM2WkzwBRg2H2qp1mA==", "2f902407-c951-4986-9601-6b1423ecdbef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b78e3aed-31d6-4943-a205-2e9e035afae9", "AQAAAAEAACcQAAAAEHB4K8xjXKbCmNpiF9D7ec7b1Ufi/OSnDiAgBP3Ujplpa6yhZqw9bcX+ytew6lE9VQ==", "cdf6a9bd-6156-4293-afef-7b536b12d15e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e87f845-4903-4bf6-a227-1f9d95d984f7", "AQAAAAEAACcQAAAAEBMgOeQZhVxSR4fjVRGN0VL9Z4epdW9POYc7BtvFZn2ynTIk0jnvDNemayb3V+dvUw==", "e7d44fbf-9528-4203-8c40-3e5f24d6a1aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80fd2a48-1cf7-4b21-acea-46e2f45cefe5", "AQAAAAEAACcQAAAAENfodrcTR4qv2+o0zOtrkzZrZZ/dNY9JGeZpj3TyoeJ1Nv9XTASXjrQ4KLlrkpV19Q==", "563ac2d6-0100-49aa-b7d0-4089fa738d97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81d6e2a2-7bd8-4d73-998f-8eb7d6991686", "AQAAAAEAACcQAAAAEKH30jsgli+XUyDQoFOpgper83bD/WWP5N6u/fn0LcB2J1pTeUZQ8L84sPgC5cSCzw==", "2dc66936-4ce9-4460-92ef-837b7d5ea354" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09869180-1fa5-4a72-b953-48e68b2e208b", "AQAAAAEAACcQAAAAEHn6i7q4opL3JkEVImtcelsYSCQgn4OhgzPNAql4l//cgWx7IiMS4UWDKgyHwMvREw==", "7d6c316b-b562-42e3-b916-64a2e688f205" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0386dbc9-3732-4f3e-95fb-b07128fa9294", "AQAAAAEAACcQAAAAELewj106+us1sE0pW1HjYesK83D0dqoye8hJiP3SJ/303VfbBONtYcUCqXs+7l76hA==", "71d64a7f-9828-4e84-92be-90e8082c37d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c30d859-a193-47c7-a95d-0555b2c6c9ba", "AQAAAAEAACcQAAAAEInXi18vn9szkXgXdICyHzu1VQ3pAaR9qwmDwVetZRUw9r1/A6uht17XrUQSW5u0Fw==", "e791e9d2-3c27-469f-99b8-25060af18816" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe0c8036-65b7-460f-bfc8-71f4de31cf8e", null, "5e1c7628-8528-46a4-8a1e-88267c6f6ef0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e41889-8273-487a-8dd2-c06d0cbcd984", null, "0e51c28d-017e-4d81-9fa3-51ea2b7a9235" });
        }
    }
}
