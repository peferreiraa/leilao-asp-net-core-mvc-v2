using Microsoft.EntityFrameworkCore.Migrations;

namespace Leilao.Migrations
{
    public partial class PessoaForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Produto_ProdutoId",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pessoa",
                newName: "Nome");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Pessoa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Produto_ProdutoId",
                table: "Pessoa",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Produto_ProdutoId",
                table: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pessoa",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Pessoa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Produto_ProdutoId",
                table: "Pessoa",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
