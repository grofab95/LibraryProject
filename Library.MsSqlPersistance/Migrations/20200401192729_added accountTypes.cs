using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.MsSqlPersistance.Migrations
{
    public partial class addedaccountTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountType_AccountTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccountType");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountTypeId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "AccountTypeId1",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountTypeId1",
                table: "Users",
                column: "AccountTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountTypes_AccountTypeId1",
                table: "Users",
                column: "AccountTypeId1",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AccountTypes_AccountTypeId1",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_AccountTypeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AccountTypeId1",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountTypeId",
                table: "Users",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AccountType_AccountTypeId",
                table: "Users",
                column: "AccountTypeId",
                principalTable: "AccountType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
