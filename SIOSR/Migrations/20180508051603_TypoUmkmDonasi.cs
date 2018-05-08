using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Migrations
{
    public partial class TypoUmkmDonasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donasi_Umkm_UmkmId",
                table: "Donasi");

            migrationBuilder.DropIndex(
                name: "IX_Donasi_UmkmId",
                table: "Donasi");

            migrationBuilder.DropColumn(
                name: "UmkmId",
                table: "Donasi");

            migrationBuilder.AddColumn<int>(
                name: "UmkmId",
                table: "PenggalanganDana",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PenggalanganDana_UmkmId",
                table: "PenggalanganDana",
                column: "UmkmId");

            migrationBuilder.AddForeignKey(
                name: "FK_PenggalanganDana_Umkm_UmkmId",
                table: "PenggalanganDana",
                column: "UmkmId",
                principalTable: "Umkm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PenggalanganDana_Umkm_UmkmId",
                table: "PenggalanganDana");

            migrationBuilder.DropIndex(
                name: "IX_PenggalanganDana_UmkmId",
                table: "PenggalanganDana");

            migrationBuilder.DropColumn(
                name: "UmkmId",
                table: "PenggalanganDana");

            migrationBuilder.AddColumn<int>(
                name: "UmkmId",
                table: "Donasi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donasi_UmkmId",
                table: "Donasi",
                column: "UmkmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donasi_Umkm_UmkmId",
                table: "Donasi",
                column: "UmkmId",
                principalTable: "Umkm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
