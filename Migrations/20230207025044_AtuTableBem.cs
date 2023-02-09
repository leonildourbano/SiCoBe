using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSisConBens.Migrations
{
    public partial class AtuTableBem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BemImagem",
                table: "Bem",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BemImagem",
                table: "Bem");
        }
    }
}
