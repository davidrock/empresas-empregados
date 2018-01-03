using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend.Database.Migrations
{
    public partial class Inclusao_de_Campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Colaboradores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtCadastro",
                table: "Colaboradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtDemissao",
                table: "Colaboradores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DtCadastro",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "DtDemissao",
                table: "Colaboradores");
        }
    }
}
