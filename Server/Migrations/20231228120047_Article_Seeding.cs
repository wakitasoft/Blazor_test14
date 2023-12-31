using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blazor_test14.Server.Migrations
{
    /// <inheritdoc />
    public partial class Article_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Content", "CreateDate", "Title", "UpdateDate" },
                values: new object[,]
                {
                    { 1, "本文1", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(324), "タイトル1", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(333) },
                    { 2, "本文2", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(334), "タイトル2", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(335) },
                    { 3, "本文3", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(336), "タイトル3", new DateTime(2023, 12, 28, 21, 0, 46, 950, DateTimeKind.Local).AddTicks(336) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
