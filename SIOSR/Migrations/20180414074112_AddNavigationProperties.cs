using Microsoft.EntityFrameworkCore.Migrations;

namespace SIOSR.Migrations
{
    public partial class AddNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UmkmId",
                table: "Donasi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pembelian_UmkmId",
                table: "Pembelian",
                column: "UmkmId");

            migrationBuilder.CreateIndex(
                name: "IX_Donasi_PenggalanganDanaId",
                table: "Donasi",
                column: "PenggalanganDanaId");

            migrationBuilder.CreateIndex(
                name: "IX_Donasi_UmkmId",
                table: "Donasi",
                column: "UmkmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donasi_PenggalanganDana_PenggalanganDanaId",
                table: "Donasi",
                column: "PenggalanganDanaId",
                principalTable: "PenggalanganDana",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donasi_Umkm_UmkmId",
                table: "Donasi",
                column: "UmkmId",
                principalTable: "Umkm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pembelian_Umkm_UmkmId",
                table: "Pembelian",
                column: "UmkmId",
                principalTable: "Umkm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donasi_PenggalanganDana_PenggalanganDanaId",
                table: "Donasi");

            migrationBuilder.DropForeignKey(
                name: "FK_Donasi_Umkm_UmkmId",
                table: "Donasi");

            migrationBuilder.DropForeignKey(
                name: "FK_Pembelian_Umkm_UmkmId",
                table: "Pembelian");

            migrationBuilder.DropIndex(
                name: "IX_Pembelian_UmkmId",
                table: "Pembelian");

            migrationBuilder.DropIndex(
                name: "IX_Donasi_PenggalanganDanaId",
                table: "Donasi");

            migrationBuilder.DropIndex(
                name: "IX_Donasi_UmkmId",
                table: "Donasi");

            migrationBuilder.DropColumn(
                name: "UmkmId",
                table: "Donasi");
        }
    }
}
