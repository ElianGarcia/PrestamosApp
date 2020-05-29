using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamosApp.Migrations
{
    public partial class First_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 40, nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PersonaID = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(maxLength: 50, nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "PersonaID", "Balance", "Cedula", "Direccion", "FechaDeNacimiento", "Nombres", "Telefono" },
                values: new object[] { 1, 345.34m, "05600345926", "Calle Roberto Acevedo #34", new DateTime(2020, 5, 29, 10, 35, 1, 585, DateTimeKind.Local).AddTicks(5991), "Juan Alberto", "8292655182" });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "ID", "Balance", "Concepto", "Fecha", "Monto", "PersonaID" },
                values: new object[] { 1, 345.34m, "Terrenos", new DateTime(2020, 5, 29, 10, 35, 1, 582, DateTimeKind.Local).AddTicks(8156), 345.34m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Prestamos");
        }
    }
}
