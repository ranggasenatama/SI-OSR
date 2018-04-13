using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Data.Migrations
{
    public partial class RemoveStatusAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PenggalanganDana");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pembelian");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Materi");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Lomba");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PenggalanganDana",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pembelian",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Materi",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Lomba",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Donasi",
                nullable: false,
                defaultValue: "");
        }
    }
}
