using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeTarefas.Data.Migrations
{
    public partial class SeedBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ListaDeTarefas",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Meu Dia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListaDeTarefas",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
