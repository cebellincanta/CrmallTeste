using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrmallTeste.Infra.Migrations
{
    public partial class InitDatabaseCrmall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    RecordSituation = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(maxLength: 6, nullable: false),
                    Complement = table.Column<string>(maxLength: 50, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 250, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal");
        }
    }
}
