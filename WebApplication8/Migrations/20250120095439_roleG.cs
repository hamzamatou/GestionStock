using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class roleG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_User_IdUserAffecting",
                table: "Affectation");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Employe_IdEmp",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_IdEmp",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Categorie",
                table: "Materiel");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Quantite",
                table: "Materiel",
                newName: "disponibilite");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "Pwd",
                table: "Users",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "IdEmp",
                table: "Users",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmployeIdEmp",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "adresse",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "datecreation",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeIdEmp",
                table: "Users",
                column: "EmployeIdEmp");

            migrationBuilder.AddForeignKey(
                name: "FK_Affectation_Users_IdUserAffecting",
                table: "Affectation",
                column: "IdUserAffecting",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Employe_EmployeIdEmp",
                table: "Users",
                column: "EmployeIdEmp",
                principalTable: "Employe",
                principalColumn: "IdEmp",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Affectation_Users_IdUserAffecting",
                table: "Affectation");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Employe_EmployeIdEmp",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EmployeIdEmp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeIdEmp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "adresse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "datecreation",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "disponibilite",
                table: "Materiel",
                newName: "Quantite");

            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "User",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "User",
                newName: "Pwd");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "User",
                newName: "IdEmp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "IdUser");

            migrationBuilder.AddColumn<string>(
                name: "Categorie",
                table: "Materiel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdEmp",
                table: "User",
                column: "IdEmp");

            migrationBuilder.AddForeignKey(
                name: "FK_Affectation_User_IdUserAffecting",
                table: "Affectation",
                column: "IdUserAffecting",
                principalTable: "User",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employe_IdEmp",
                table: "User",
                column: "IdEmp",
                principalTable: "Employe",
                principalColumn: "IdEmp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
