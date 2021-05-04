using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class singular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "PetAccomodationId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets",
                column: "PetAccomodationId",
                principalTable: "PetAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "PetAccomodationId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets",
                column: "PetAccomodationId",
                principalTable: "PetAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
