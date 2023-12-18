using Microsoft.EntityFrameworkCore.Migrations;

namespace WebComputos.AccesoDatos.Migrations
{
    public partial class Causales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "Causales",
                columns: table => new
                {
                    IdCausales = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCasillaDet = table.Column<int>(nullable: false),
                    PaqSinAec = table.Column<string>(nullable: true),
                    VotosNMayor = table.Column<string>(nullable: true),
                    VotosSisBol = table.Column<string>(nullable: true),
                    VotosSisAec = table.Column<string>(nullable: true),
                    VotosPartido = table.Column<string>(nullable: true),
                    ActaIlegible = table.Column<string>(nullable: true),
                    ActAlteraciones = table.Column<string>(nullable: true),
                    PaqAlteraciones = table.Column<string>(nullable: true),
                    CiuVotaron = table.Column<string>(nullable: true),
                    BoletasSisCiu = table.Column<string>(nullable: true),
                    BoletasSisTot = table.Column<string>(nullable: true),
                    NumCausales = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Causales", x => x.IdCausales);
                    table.ForeignKey(
                        name: "FK_Causales_TCasillaDet_IdCasillaDet",
                        column: x => x.IdCasillaDet,
                        principalTable: "TCasillaDet",
                        principalColumn: "IdCasillaDet",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Causales_IdCasillaDet",
                table: "Causales",
                column: "IdCasillaDet");
        
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Causales");
        }
    }
}
