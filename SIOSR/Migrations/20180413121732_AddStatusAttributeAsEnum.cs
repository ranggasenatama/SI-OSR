using Microsoft.EntityFrameworkCore.Migrations;

namespace SIOSR.Migrations
{
    public partial class AddStatusAttributeAsEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Umkm",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PenggalanganDana",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pembelian",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Donasi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Umkm");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PenggalanganDana");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pembelian");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donasi");
        }
    }
}
