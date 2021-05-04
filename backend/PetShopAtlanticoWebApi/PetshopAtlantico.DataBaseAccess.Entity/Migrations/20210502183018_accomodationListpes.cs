using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class accomodationListpes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetsOwner_Pets_petId",
                table: "PetsOwner");

            migrationBuilder.DropColumn(
                name: "IdPet",
                table: "PetsOwner");

            migrationBuilder.RenameColumn(
                name: "petId",
                table: "PetsOwner",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_PetsOwner_petId",
                table: "PetsOwner",
                newName: "IX_PetsOwner_PetId");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "PetsOwner",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetAccomodationId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetOwnerId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_PetAccomodationId",
                table: "Pets",
                column: "PetAccomodationId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetAccomodations_PetAccomodationId",
                table: "Pets");

            migrationBuilder.DropForeignKey(
                name: "FK_PetsOwner_Pets_PetId",
                table: "PetsOwner");

            migrationBuilder.DropIndex(
                name: "IX_Pets_PetAccomodationId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetAccomodationId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetOwnerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "PetsOwner",
                newName: "petId");

            migrationBuilder.RenameIndex(
                name: "IX_PetsOwner_PetId",
                table: "PetsOwner",
                newName: "IX_PetsOwner_petId");

            migrationBuilder.AlterColumn<int>(
                name: "petId",
                table: "PetsOwner",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdPet",
                table: "PetsOwner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PetsOwner_Pets_petId",
                table: "PetsOwner",
                column: "petId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
