using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class relationpetowner_petOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsOwner_Pets_PetId",
                table: "PetsOwner");

            migrationBuilder.DropIndex(
                name: "IX_PetsOwner_PetId",
                table: "PetsOwner");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "PetsOwner");

            migrationBuilder.AlterColumn<int>(
                name: "PetAccomodationId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets",
                column: "PetAccomodationId",
                principalTable: "PetAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetsOwner_PetOwnerId",
                table: "Pets",
                column: "PetOwnerId",
                principalTable: "PetsOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetsOwner_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetOwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "PetsOwner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PetAccomodationId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_PetsOwner_PetId",
                table: "PetsOwner",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets",
                column: "PetAccomodationId",
                principalTable: "PetAccomodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetsOwner_Pets_PetId",
                table: "PetsOwner",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
