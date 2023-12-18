using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class Causaele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "IdEleccion",
                table: "Causales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Causales_IdEleccion",
                table: "Causales",
                column: "IdEleccion");

            migrationBuilder.AddForeignKey(
                name: "FK_Causales_TtipoEleccion_IdEleccion",
                table: "Causales",
                column: "IdEleccion",
                principalTable: "TtipoEleccion",
                principalColumn: "idTipoEleccion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Causales_TtipoEleccion_IdEleccion",
                table: "Causales");

            migrationBuilder.DropIndex(
                name: "IX_Causales_IdEleccion",
                table: "Causales");

            migrationBuilder.DropColumn(
                name: "IdEleccion",
                table: "Causales");

            
        }
    }
}
