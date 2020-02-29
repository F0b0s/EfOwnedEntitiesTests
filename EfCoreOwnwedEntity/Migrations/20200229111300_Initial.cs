using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreOwnwedEntitySqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Settings_StandartAccess = table.Column<bool>(nullable: true, defaultValue: false),
                    Settings_ExtendedAcces = table.Column<bool>(nullable: true, defaultValue: false),
                    Settings_Flag1 = table.Column<bool>(nullable: true, defaultValue: false),
                    Settings_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
