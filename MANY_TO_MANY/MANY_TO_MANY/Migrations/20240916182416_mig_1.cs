using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MANY_TO_MANY.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KİTAPLAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KİTAPLAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YAZARLAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YAZARLAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KİTAPYAZAR",
                columns: table => new
                {
                    KİTAPId = table.Column<int>(type: "int", nullable: false),
                    YAZARId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KİTAPYAZAR", x => new { x.KİTAPId, x.YAZARId });
                    table.ForeignKey(
                        name: "FK_KİTAPYAZAR_KİTAPLAR_KİTAPId",
                        column: x => x.KİTAPId,
                        principalTable: "KİTAPLAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KİTAPYAZAR_YAZARLAR_YAZARId",
                        column: x => x.YAZARId,
                        principalTable: "YAZARLAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KİTAPYAZAR_YAZARId",
                table: "KİTAPYAZAR",
                column: "YAZARId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KİTAPYAZAR");

            migrationBuilder.DropTable(
                name: "KİTAPLAR");

            migrationBuilder.DropTable(
                name: "YAZARLAR");
        }
    }
}
