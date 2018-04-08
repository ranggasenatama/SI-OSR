using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SIOSR.Data.Migrations
{
    public partial class AddAllAppModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Donasis",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Donasis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Absensi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Kehadiran = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absensi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Parent = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lomba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lomba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pembelian",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccountNumber = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 128, nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Shipping = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pembelian", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Umkm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    Type = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umkm", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absensi");

            migrationBuilder.DropTable(
                name: "Anak");

            migrationBuilder.DropTable(
                name: "Lomba");

            migrationBuilder.DropTable(
                name: "Materi");

            migrationBuilder.DropTable(
                name: "Pembelian");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Umkm");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Donasis");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Donasis",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
