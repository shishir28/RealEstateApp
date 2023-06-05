using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookmarkId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Bookmarks");

            migrationBuilder.AddColumn<Guid>(
                name: "BookmarkId",
                table: "Bookmarks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "BookmarkId");

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "BookmarkId", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PropertyId", "Status", "User_Id" },
                values: new object[] { new Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f"), true, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks");

            migrationBuilder.DeleteData(
                table: "Bookmarks",
                keyColumn: "BookmarkId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("a46ab603-903e-4460-9ba7-da5f3f0f9e92"));

            migrationBuilder.DropColumn(
                name: "BookmarkId",
                table: "Bookmarks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Bookmarks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookmarks",
                table: "Bookmarks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Bookmarks",
                columns: new[] { "Id", "Created", "CreatedBy", "LastModified", "LastModifiedBy", "PropertyId", "Status", "User_Id" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, new Guid("d9f9b9b0-5b9a-4b9c-9c9d-9b9b9b9b9b9f"), true, 1 });
        }
    }
}
