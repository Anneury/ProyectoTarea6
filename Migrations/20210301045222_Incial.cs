using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoTarea6.Migrations
{
    public partial class Incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombrePermiso = table.Column<string>(type: "TEXT", nullable: true),
                    DescripcionPermiso = table.Column<string>(type: "TEXT", nullable: true),
                    VecesAsignado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisoID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionRol = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    esActivo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    AliasUsuario = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Clave = table.Column<string>(type: "TEXT", nullable: true),
                    FechaUsuario = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Rol = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "RolesDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolID = table.Column<int>(type: "INTEGER", nullable: false),
                    PermisoID = table.Column<int>(type: "INTEGER", nullable: false),
                    esAsignado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RolesDetalle_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoID", "DescripcionPermiso", "NombrePermiso", "VecesAsignado" },
                values: new object[] { 1, "Este permiso puede modificar el precio", "Descuenta", 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoID", "DescripcionPermiso", "NombrePermiso", "VecesAsignado" },
                values: new object[] { 2, "Este permiso puede vender productos", "Vende", 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisoID", "DescripcionPermiso", "NombrePermiso", "VecesAsignado" },
                values: new object[] { 3, "Este permiso puede cobrar dinero", "Cobra", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_RolesDetalle_RolID",
                table: "RolesDetalle",
                column: "RolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RolesDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
