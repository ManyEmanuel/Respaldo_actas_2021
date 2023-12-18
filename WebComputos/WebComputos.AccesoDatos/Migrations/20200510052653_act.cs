using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class act : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            

            migrationBuilder.AddColumn<int>(
                name: "IdDetalleActa",
                table: "TActas",
                nullable: false,
                defaultValue: 0);

           

            migrationBuilder.CreateIndex(
                name: "IX_TActas_IdDetalleActa",
                table: "TActas",
                column: "IdDetalleActa");

            migrationBuilder.AddForeignKey(
                name: "FK_TActas_DetallesActas_IdDetalleActa",
                table: "TActas",
                column: "IdDetalleActa",
                principalTable: "DetallesActas",
                principalColumn: "IdActaDetalle",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TActas_DetallesActas_IdDetalleActa",
                table: "TActas");

            migrationBuilder.DropIndex(
                name: "IX_TActas_IdDetalleActa",
                table: "TActas");

            migrationBuilder.DropColumn(
                name: "IdDetalleActa",
                table: "TActas");

           

            migrationBuilder.AddColumn<int>(
                name: "IdCasillaDet",
                table: "TActas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TActas_IdCasillaDet",
                table: "TActas",
                column: "IdCasillaDet");

            migrationBuilder.AddForeignKey(
                name: "FK_TActas_TCasillaDet_IdCasillaDet",
                table: "TActas",
                column: "IdCasillaDet",
                principalTable: "TCasillaDet",
                principalColumn: "IdCasillaDet",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
