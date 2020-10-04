using Microsoft.EntityFrameworkCore.Migrations;

namespace BLVGestao.Data.Migrations
{
    public partial class AlteracaoProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantidade",
                table: "Produto",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produto");
        }
    }
}
