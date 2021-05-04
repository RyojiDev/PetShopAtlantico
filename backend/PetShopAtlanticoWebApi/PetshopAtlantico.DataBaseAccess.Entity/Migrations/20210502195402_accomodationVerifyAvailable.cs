using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopAtlanticoWebApi.Migrations
{
    public partial class accomodationVerifyAvailable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "PetAccomodations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "PetAccomodations");
        }
    }
}
