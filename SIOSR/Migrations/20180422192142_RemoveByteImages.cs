using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Migrations
{
    public partial class RemoveByteImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Umkm",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PenggalanganDana",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Materi",
                nullable: true);
        }
    }
}
