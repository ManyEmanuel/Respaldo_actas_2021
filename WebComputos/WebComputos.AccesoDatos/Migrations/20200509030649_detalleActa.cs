using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class detalleActa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "IdCasillaDet",
                table: "TActas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DetallesActas",
                columns: table => new
                {
                    IdActaDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCasillaDet = table.Column<int>(nullable: false),
                    IdEleccion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesActas", x => x.IdActaDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesActas_TCasillaDet_IdCasillaDet",
                        column: x => x.IdCasillaDet,
                        principalTable: "TCasillaDet",
                        principalColumn: "IdCasillaDet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesActas_TtipoEleccion_IdEleccion",
                        column: x => x.IdEleccion,
                        principalTable: "TtipoEleccion",
                        principalColumn: "idTipoEleccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TActas_Estatus",
                table: "TActas",
                column: "Estatus");

            migrationBuilder.CreateIndex(
                name: "IX_TActas_IdCasillaDet",
                table: "TActas",
                column: "IdCasillaDet");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesActas_IdCasillaDet",
                table: "DetallesActas",
                column: "IdCasillaDet");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesActas_IdEleccion",
                table: "DetallesActas",
                column: "IdEleccion");

            migrationBuilder.AddForeignKey(
                name: "FK_TActas_EstatusActas_Estatus",
                table: "TActas",
                column: "Estatus",
                principalTable: "EstatusActas",
                principalColumn: "IdEstatus",
                onDelete: ReferentialAction.Cascade);

      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TActas_EstatusActas_Estatus",
                table: "TActas");

       

            migrationBuilder.DropTable(
                name: "DetallesActas");

            migrationBuilder.DropIndex(
                name: "IX_TActas_Estatus",
                table: "TActas");

            migrationBuilder.DropIndex(
                name: "IX_TActas_IdCasillaDet",
                table: "TActas");

            migrationBuilder.DropColumn(
                name: "IdCasillaDet",
                table: "TActas");

            migrationBuilder.AddColumn<int>(
                name: "IdRecepcionDet",
                table: "TActas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TActas_IdRecepcionDet",
                table: "TActas",
                column: "IdRecepcionDet");

            migrationBuilder.AddForeignKey(
                name: "FK_TActas_RecepcionDetalle_IdRecepcionDet",
                table: "TActas",
                column: "IdRecepcionDet",
                principalTable: "RecepcionDetalle",
                principalColumn: "IdRecepcionDetalle",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
