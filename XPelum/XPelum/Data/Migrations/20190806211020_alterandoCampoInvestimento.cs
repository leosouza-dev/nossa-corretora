using Microsoft.EntityFrameworkCore.Migrations;

namespace XPelum.Data.Migrations
{
    public partial class alterandoCampoInvestimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Investimento",
                table: "Acessoria",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Investimento",
                table: "Acessoria",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
