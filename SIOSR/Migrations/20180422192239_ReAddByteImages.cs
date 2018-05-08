using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Migrations
{
    public partial class ReAddByteImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Umkm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "PenggalanganDana",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Materi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Umkm");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "PenggalanganDana");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Materi");
        }
    }
}
