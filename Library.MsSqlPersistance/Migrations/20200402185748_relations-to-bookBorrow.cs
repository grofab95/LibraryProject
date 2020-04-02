using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.MsSqlPersistance.Migrations
{
    public partial class relationstobookBorrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Users_UserId",
                table: "BookBorrows");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnDate",
                table: "BookBorrows",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Users_UserId",
                table: "BookBorrows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrows_Users_UserId",
                table: "BookBorrows");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "BookBorrows");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Books_BookId",
                table: "BookBorrows",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrows_Users_UserId",
                table: "BookBorrows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
