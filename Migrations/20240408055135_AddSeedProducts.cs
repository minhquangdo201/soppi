using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace soppi.Migrations
{
    public partial class AddSeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92877374-c493-42eb-aecb-671c6d23a4a1", "AQAAAAEAACcQAAAAEOWO41bfl1f6AsQIWJ7NtSzmqiFI+IQis5KIsXzbd0dDDY9fMp+Ct9Vv2VVWRY5KlA==", "7cfbab16-2411-4e40-a9e8-92792e0a2db0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88cbcee1-586d-49c1-9a67-2e00cf64d939", "AQAAAAEAACcQAAAAEG8V5d8jDy5o226P54HpIGIPGrrbwmKNzNl+Q7HKisYtU+KpJCjzKf0+EGWEZzs/IA==", "ba5490f6-8e41-44eb-971b-a26a607739e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e2524bf-3d30-42cd-a653-ff7ab1504939", "AQAAAAEAACcQAAAAEFJFKbMX6doWwbk5tUilzR3GSfemofkICET/r3WmMQjHADxUrrDJmXNbh5lhOsbRKQ==", "f26324da-7923-4970-84cf-20cd39fa393a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9163c376-4311-4482-a574-af6a3b529707", "AQAAAAEAACcQAAAAEO2+KB1oNchtAUKmUkXNYrqgZ/6KMJ8rF03AL+mc2tQfry4EwiZBIwWq4IVE13o46A==", "9c71ec47-749b-4708-af9a-a4d5fc460b32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25dc0ac1-d63f-435c-be5c-3a5f75df5de5", "AQAAAAEAACcQAAAAELj5QpDwavz6bmbngA/FJrbjLAr2JxzVBJRxyzD4X6B5qp88vItvTpDff1SYnS7qHw==", "79df4ef2-a61b-4b81-85f3-0ddb97725d26" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
