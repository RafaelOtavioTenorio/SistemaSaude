using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaSaude.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoConsulta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataConsulta = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LocalConsulta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Medico = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Paciente = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataNasc = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DataNasc = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CartaoSUS = table.Column<int>(type: "bigint", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
