using Microsoft.EntityFrameworkCore.Migrations;

namespace BLVGestao.Data.Migrations
{
    public partial class RevertendoAlteracaoPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId1",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_Pessoa_PessoaId1",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_PessoaId1",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_PessoaId1",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "PessoaId1",
                table: "Telefone");

            migrationBuilder.DropColumn(
                name: "PessoaId1",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PessoaId1",
                table: "Telefone",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId1",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PessoaId1",
                table: "Telefone",
                column: "PessoaId1",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId1",
                table: "Endereco",
                column: "PessoaId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId1",
                table: "Endereco",
                column: "PessoaId1",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_Pessoa_PessoaId1",
                table: "Telefone",
                column: "PessoaId1",
                principalTable: "Pessoa",
                principalColumn: "PessoaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
