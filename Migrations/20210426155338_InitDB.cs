using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibraryManager.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passwords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDetails",
                columns: table => new
                {
                    BookID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDetails", x => new { x.BookID, x.RequestID });
                    table.ForeignKey(
                        name: "FK_RequestDetails_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDetails_Requests_RequestID",
                        column: x => x.RequestID,
                        principalTable: "Requests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "Created", "Modified", "Name" },
                values: new object[,]
                {
                    { new Guid("ec705bf3-7e8e-4be2-8894-07d41c6166d9"), new DateTime(2021, 4, 26, 22, 53, 37, 576, DateTimeKind.Local).AddTicks(7376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Math" },
                    { new Guid("2bc95077-bc27-414a-aa34-e03cf2a1da89"), new DateTime(2021, 4, 26, 22, 53, 37, 576, DateTimeKind.Local).AddTicks(7391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Created", "Modified", "Passwords", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("f49bac34-00b5-434d-abd0-cee7e5e07298"), new DateTime(2021, 4, 26, 22, 53, 37, 574, DateTimeKind.Local).AddTicks(8014), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", 1, "admin" },
                    { new Guid("477e6f33-344d-481c-8a1a-a0fe375a795c"), new DateTime(2021, 4, 26, 22, 53, 37, 575, DateTimeKind.Local).AddTicks(6631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", 0, "AnhTQ" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "CategoryID", "Created", "IsAvailable", "Modified", "Name" },
                values: new object[] { new Guid("41c45420-ac0b-4ab1-94bf-4b545d8eda36"), "NXB", new Guid("ec705bf3-7e8e-4be2-8894-07d41c6166d9"), new DateTime(2021, 4, 26, 22, 53, 37, 576, DateTimeKind.Local).AddTicks(9077), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Math 11" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "CategoryID", "Created", "IsAvailable", "Modified", "Name" },
                values: new object[] { new Guid("fc0e38bb-4b1c-4050-b094-9a072a56e23e"), "NXB", new Guid("ec705bf3-7e8e-4be2-8894-07d41c6166d9"), new DateTime(2021, 4, 26, 22, 53, 37, 576, DateTimeKind.Local).AddTicks(9091), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Math 12" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "CategoryID", "Created", "IsAvailable", "Modified", "Name" },
                values: new object[] { new Guid("82015663-f63c-48d1-887b-dcb3104125de"), "NXB", new Guid("2bc95077-bc27-414a-aa34-e03cf2a1da89"), new DateTime(2021, 4, 26, 22, 53, 37, 576, DateTimeKind.Local).AddTicks(9094), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Literatue 12" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDetails_RequestID",
                table: "RequestDetails",
                column: "RequestID");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserID",
                table: "Requests",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDetails");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
