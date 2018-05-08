using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Migrations
{
    public partial class RemoveShipping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Shipping",
                table: "Pembelian");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UmkmId",
                table: "PenggalanganDana",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shipping",
                table: "Pembelian",
                nullable: false,
                defaultValue: "");

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
    }
}
