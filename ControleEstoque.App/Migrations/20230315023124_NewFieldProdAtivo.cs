using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleEstoque.App.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldProdAtivo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProdAtivo",
                table: "Product",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdAtivo",
                table: "Product");
        }
    }
}
