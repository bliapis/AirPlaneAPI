using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.TesteGol.Infra.Data.Airplane.Migrations
{
    public partial class _0001IniciandoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirPlanes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    QtdPassageiros = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPlanes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirPlanes");
        }
    }
}
