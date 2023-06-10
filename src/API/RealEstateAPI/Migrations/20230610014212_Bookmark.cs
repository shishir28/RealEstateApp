using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAPI.Migrations
{
    /// <inheritdoc />
    public partial class Bookmark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Bookmarks");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Bookmarks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "BookmarkId",
                keyValue: new Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"),
                column: "UserId",
                value: new Guid("8399c62e-d0b4-49bc-a8c6-0a7a0446c159"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookmarks");

            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bookmarks",
                keyColumn: "BookmarkId",
                keyValue: new Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"),
                column: "User_Id",
                value: 1);
        }
    }
}
