using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetJardin.Migrations
{
    /// <inheritdoc />
    public partial class project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sucre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitamine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Jardins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surface = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jardins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlimentJardin",
                columns: table => new
                {
                    AlimentID = table.Column<int>(type: "int", nullable: false),
                    JardinsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentJardin", x => new { x.AlimentID, x.JardinsId });
                    table.ForeignKey(
                        name: "FK_AlimentJardin_Aliment_AlimentID",
                        column: x => x.AlimentID,
                        principalTable: "Aliment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentJardin_Jardins_JardinsId",
                        column: x => x.JardinsId,
                        principalTable: "Jardins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentJardin_JardinsId",
                table: "AlimentJardin",
                column: "JardinsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentJardin");

            migrationBuilder.DropTable(
                name: "Aliment");

            migrationBuilder.DropTable(
                name: "Jardins");
        }
    }
}
