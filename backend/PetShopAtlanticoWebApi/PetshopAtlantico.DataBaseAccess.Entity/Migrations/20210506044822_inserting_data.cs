using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class inserting_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetAccomodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "PetAccomodations",
                columns: new[] { "PetAccomodationId", "AccommodationStatus", "Available", "Name" },
                values: new object[,]
                {
                    { 1, 0, true, "Alojamento num 1" },
                    { 2, 0, false, "Alojamento num 2" },
                    { 3, 0, true, "Alojamento num 3" },
                    { 4, 0, true, "Alojamento num 4" },
                    { 5, 0, true, "Alojamento num 5" },
                    { 6, 0, true, "Alojamento num 6" },
                    { 7, 0, true, "Alojamento num 7" },
                    { 8, 0, true, "Alojamento num 8" },
                    { 9, 0, true, "Alojamento num 9" },
                    { 10, 0, true, "Alojamento num 10" },
                    { 11, 0, true, "Alojamento num 11" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PetAccomodations",
                keyColumn: "PetAccomodationId",
                keyValue: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "PetAccomodations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
