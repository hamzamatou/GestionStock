using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class firstM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materiel",
                columns: table => new
                {
                    IdMat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateAffectation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Etat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SystemExp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantite = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiel", x => x.IdMat);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materiel");
        }
    }
}
