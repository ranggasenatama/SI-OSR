using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Data.Migrations
{
    public partial class AddMissingForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UmkmId",
                table: "Pembelian",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PenggalanganDanaId",
                table: "Donasi",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UmkmId",
                table: "Pembelian");

            migrationBuilder.DropColumn(
                name: "PenggalanganDanaId",
                table: "Donasi");
        }
    }
}
