using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class reseau : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdresseMac",
                table: "Materiel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Materiel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NombrePort",
                table: "Materiel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "marque",
                table: "Materiel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdresseMac",
                table: "Materiel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Materiel");

            migrationBuilder.DropColumn(
                name: "NombrePort",
                table: "Materiel");

            migrationBuilder.DropColumn(
                name: "marque",
                table: "Materiel");
        }
    }
}
