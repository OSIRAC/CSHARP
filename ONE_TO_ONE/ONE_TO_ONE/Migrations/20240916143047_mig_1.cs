using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONE_TO_ONE.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COUNTRIES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CAPİTALS",
                columns: table => new
                {
                    COUNTRYId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAPİTALS", x => x.COUNTRYId);
                    table.ForeignKey(
                        name: "FK_CAPİTALS_COUNTRIES_COUNTRYId",
                        column: x => x.COUNTRYId,
                        principalTable: "COUNTRIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CAPİTALS");

            migrationBuilder.DropTable(
                name: "COUNTRIES");
        }
    }
}
