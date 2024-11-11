using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEFİRST.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration  // MİGRATİON İŞLEMİ KODLARIMIZI VERİ TABANININ ANLAYACAĞI ŞEKLE GETİRME İŞLEMİDİR DAHA İYİ BİR ŞEKİLDE
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // UP METHODU TETİKLENİRSE BİR ŞEYLER YAPARIZ
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)  // DOWN METHODU TETİKLENİRSE GERİYE ALMA İŞLEMİDİR
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
