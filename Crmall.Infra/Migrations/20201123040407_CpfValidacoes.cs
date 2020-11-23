using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmallTeste.Infra.Migrations
{
    public partial class CpfValidacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Personal",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Personal",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Personal",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Personal",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Personal");

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "Personal",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Personal",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Personal",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
