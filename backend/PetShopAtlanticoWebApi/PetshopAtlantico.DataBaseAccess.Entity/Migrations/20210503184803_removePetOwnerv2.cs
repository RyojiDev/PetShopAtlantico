using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class removePetOwnerv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PetsOwner",
                newName: "PetOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PetOwnerId",
                table: "PetsOwner",
                newName: "Id");
        }
    }
}
