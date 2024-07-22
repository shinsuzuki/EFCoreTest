﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirst_kindle.Migrations
{
    /// <inheritdoc />
    public partial class V0005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarCodeA",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BarCodeB",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarCodeA",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BarCodeB",
                table: "Products");
        }
    }
}
