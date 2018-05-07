using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Pembelian");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Pembelian");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Donasi");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Pembelian",
                newName: "Total");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Staff",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Lomba",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Anak",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Lomba");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Anak");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Pembelian",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Pembelian",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Pembelian",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Donasi",
                nullable: true);
        }
    }
}
