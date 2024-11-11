using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONE_TO_MANY.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEPARTMANLAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMANLAR", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CALISANLAR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DEPARTMANId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CALISANLAR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CALISANLAR_DEPARTMANLAR_DEPARTMANId",
                        column: x => x.DEPARTMANId,
                        principalTable: "DEPARTMANLAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CALISANLAR_DEPARTMANId",
                table: "CALISANLAR",
                column: "DEPARTMANId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CALISANLAR");

            migrationBuilder.DropTable(
                name: "DEPARTMANLAR");
        }
    }
}
