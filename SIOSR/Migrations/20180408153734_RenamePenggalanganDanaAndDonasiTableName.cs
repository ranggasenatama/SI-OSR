using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Data.Migrations
{
    public partial class RenamePenggalanganDanaAndDonasiTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PenggalanganDanas",
                table: "PenggalanganDanas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donasis",
                table: "Donasis");

            migrationBuilder.RenameTable(
                name: "PenggalanganDanas",
                newName: "PenggalanganDana");

            migrationBuilder.RenameTable(
                name: "Donasis",
                newName: "Donasi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PenggalanganDana",
                table: "PenggalanganDana",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donasi",
                table: "Donasi",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PenggalanganDana",
                table: "PenggalanganDana");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Donasi",
                table: "Donasi");

            migrationBuilder.RenameTable(
                name: "PenggalanganDana",
                newName: "PenggalanganDanas");

            migrationBuilder.RenameTable(
                name: "Donasi",
                newName: "Donasis");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PenggalanganDanas",
                table: "PenggalanganDanas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Donasis",
                table: "Donasis",
                column: "Id");
        }
    }
}
