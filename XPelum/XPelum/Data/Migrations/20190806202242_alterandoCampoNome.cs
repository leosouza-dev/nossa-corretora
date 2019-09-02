using Microsoft.EntityFrameworkCore.Migrations;

namespace XPelum.Data.Migrations
{
    public partial class alterandoCampoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "investimento",
                table: "Acessoria",
                newName: "Investimento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Acessoria",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Investimento",
                table: "Acessoria",
                newName: "investimento");

            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Acessoria",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
