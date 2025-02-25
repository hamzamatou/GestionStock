using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiel_BonDachat_idBonDentree",
                table: "Materiel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDachat",
                table: "BonDachat");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Employe");

            migrationBuilder.RenameTable(
                name: "BonDachat",
                newName: "BonDentre");

            migrationBuilder.RenameColumn(
                name: "dateEntree",
                table: "BonDentre",
                newName: "DateEntree");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEmbauche",
                table: "Employe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateNaissance",
                table: "Employe",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Poste",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Service",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "Employe",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDentre",
                table: "BonDentre",
                column: "idBonDentre");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiel_BonDentre_idBonDentree",
                table: "Materiel",
                column: "idBonDentree",
                principalTable: "BonDentre",
                principalColumn: "idBonDentre",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiel_BonDentre_idBonDentree",
                table: "Materiel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BonDentre",
                table: "BonDentre");

            migrationBuilder.DropColumn(
                name: "DateEmbauche",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "DateNaissance",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "Poste",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "Service",
                table: "Employe");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "Employe");

            migrationBuilder.RenameTable(
                name: "BonDentre",
                newName: "BonDachat");

            migrationBuilder.RenameColumn(
                name: "DateEntree",
                table: "BonDachat",
                newName: "dateEntree");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Employe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BonDachat",
                table: "BonDachat",
                column: "idBonDentre");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiel_BonDachat_idBonDentree",
                table: "Materiel",
                column: "idBonDentree",
                principalTable: "BonDachat",
                principalColumn: "idBonDentre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
