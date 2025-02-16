using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class test100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FrsMat");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "codefiscale",
                table: "Materiel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "idBonDentree",
                table: "Materiel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BonDachat",
                columns: table => new
                {
                    idBonDentre = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dateEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonDachat", x => x.idBonDentre);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiel_codefiscale",
                table: "Materiel",
                column: "codefiscale");

            migrationBuilder.CreateIndex(
                name: "IX_Materiel_idBonDentree",
                table: "Materiel",
                column: "idBonDentree");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiel_BonDachat_idBonDentree",
                table: "Materiel",
                column: "idBonDentree",
                principalTable: "BonDachat",
                principalColumn: "idBonDentre",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiel_Fournisseur_codefiscale",
                table: "Materiel",
                column: "codefiscale",
                principalTable: "Fournisseur",
                principalColumn: "CodeFiscal",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiel_BonDachat_idBonDentree",
                table: "Materiel");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiel_Fournisseur_codefiscale",
                table: "Materiel");

            migrationBuilder.DropTable(
                name: "BonDachat");

            migrationBuilder.DropIndex(
                name: "IX_Materiel_codefiscale",
                table: "Materiel");

            migrationBuilder.DropIndex(
                name: "IX_Materiel_idBonDentree",
                table: "Materiel");

            migrationBuilder.DropColumn(
                name: "codefiscale",
                table: "Materiel");

            migrationBuilder.DropColumn(
                name: "idBonDentree",
                table: "Materiel");

            migrationBuilder.AddColumn<string>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FrsMat",
                columns: table => new
                {
                    IdMateriel = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CodeFournisseur = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PrixU = table.Column<double>(type: "float", nullable: false),
                    Quantite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrsMat", x => new { x.IdMateriel, x.CodeFournisseur });
                    table.ForeignKey(
                        name: "FK_FrsMat_Fournisseur_CodeFournisseur",
                        column: x => x.CodeFournisseur,
                        principalTable: "Fournisseur",
                        principalColumn: "CodeFiscal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FrsMat_Materiel_IdMateriel",
                        column: x => x.IdMateriel,
                        principalTable: "Materiel",
                        principalColumn: "IdMat",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_FrsMat_CodeFournisseur",
                table: "FrsMat",
                column: "CodeFournisseur");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetRoles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
