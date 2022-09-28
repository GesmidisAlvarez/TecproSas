using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecproSas.App.Persistencia.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    nacionalidad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    direccionCliente = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    faseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreFase = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    fechaInicioFase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    visitas = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fechaVisitas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actualizacionVisita = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.faseId);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    servicioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombServicio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    valor = table.Column<int>(type: "int", nullable: false),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.servicioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    apellidos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rol = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<int>(type: "int", nullable: false),
                    nicknname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    contrasenia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    loginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuarioId = table.Column<int>(type: "int", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccionIp = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.loginId);
                    table.ForeignKey(
                        name: "FK_Login_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Login_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    proyectoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteId = table.Column<int>(type: "int", nullable: true),
                    servicioId = table.Column<int>(type: "int", nullable: true),
                    faseId = table.Column<int>(type: "int", nullable: true),
                    nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    aprobadoPor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    presupuesto = table.Column<int>(type: "int", nullable: false),
                    tiempoEjecucion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    faseActual = table.Column<int>(type: "int", nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.proyectoId);
                    table.ForeignKey(
                        name: "FK_Proyectos_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Fases_faseId",
                        column: x => x.faseId,
                        principalTable: "Fases",
                        principalColumn: "faseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Servicios_servicioId",
                        column: x => x.servicioId,
                        principalTable: "Servicios",
                        principalColumn: "servicioId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proyectos_Usuarios_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "usuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_clienteId",
                table: "Login",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Login_usuarioId",
                table: "Login",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_clienteId",
                table: "Proyectos",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_faseId",
                table: "Proyectos",
                column: "faseId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_servicioId",
                table: "Proyectos",
                column: "servicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyectos_usuarioId",
                table: "Proyectos",
                column: "usuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
