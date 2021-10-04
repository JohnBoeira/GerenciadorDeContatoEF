using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeContato.ClassLibrary.Migrations
{
    public partial class CriandoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBContato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contatoId = table.Column<int>(type: "int", nullable: true),
                    numero = table.Column<int>(type: "INT", nullable: false),
                    ddd = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTelefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTelefone_TBContato_contatoId",
                        column: x => x.contatoId,
                        principalTable: "TBContato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBTelefone_contatoId",
                table: "TBTelefone",
                column: "contatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBTelefone");

            migrationBuilder.DropTable(
                name: "TBContato");
        }
    }
}
