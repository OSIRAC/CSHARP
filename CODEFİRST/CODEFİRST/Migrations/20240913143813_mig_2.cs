using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CODEFİRST.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(  // YAPMASI GEREKEN DİĞER MİGRATİONLA OLAN FARKTIR EN SON COLUMN SİLİYORMUŞ
                name: "Price",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)  // TERSİDE EKLEMEKTİR
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Products",
                type: "real",
                nullable: false,   // UPDATE DATABASE MİGRATİON BİZİ O MİGRATİONA OLAN KISMA GERİ GÖTÜRÜR VE UYGULAR REVERT EDİLİR   
                // UPDATE DATABASE DERSEK SONRA ARADA KALAN MİGRATİONLARI MİGRATE EDER REVERT EDİLENİ YANİ
                defaultValue: 0f);
                // MİGRATİON HİSTORY DE VERİ TABANINA UYGULANAN MİGRATİONLAR LİSTELENİR
                // MİGRATİONLARA GERİ DÖNÜNCE KODDA OLUŞCAK TUTARSIZLIĞA MANUEL ETKİ ETMELİİSN
        }
    }
}
