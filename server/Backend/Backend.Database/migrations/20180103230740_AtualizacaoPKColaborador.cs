using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend.Database.Migrations
{
    public partial class AtualizacaoPKColaborador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaboradores",
                table: "Colaboradores");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Colaboradores",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaboradores",
                table: "Colaboradores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EmpresaId",
                table: "Colaboradores",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Colaboradores",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_EmpresaId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Colaboradores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colaboradores",
                table: "Colaboradores",
                columns: new[] { "EmpresaId", "PessoaId" });
        }
    }
}
