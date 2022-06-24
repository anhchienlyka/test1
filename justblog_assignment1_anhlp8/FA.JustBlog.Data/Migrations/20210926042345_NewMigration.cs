using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FA.JustBlog.Data.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RateCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalRate = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CommandTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 9, 26, 4, 23, 45, 281, DateTimeKind.Utc).AddTicks(7803)),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMap",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMap", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMap_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMap_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Modified", "Name", "PostedOn", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "des 1", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat 1", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat-1" },
                    { 2, "des 2", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat 2", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat-2" },
                    { 3, "des 3", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat 3", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "cat-3" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Modified", "Name", "PostedOn", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 109, "des 1", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag 1", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag-1" },
                    { 2, 400, "des 2", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag 2", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag-2" },
                    { 3, 500, "des 3", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag 3", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "tag-3" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 1, 1, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "content 1", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), 10, "des 1", "title 1", 109, "title-1", 100 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 2, 2, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "content 2", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), 10, "des 2", "title 2", 200, "title-2", 200 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[] { 3, 3, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "content 3", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), null, 200, "des 3", "title 3", 400, "title-3", 150 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommandTime", "CommentHeader", "CommentText", "Email", "Modified", "Name", "PostId", "PostedOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "header 1", "text 1", "user1@mail.com", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "user 1", 1, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "header 2", "text 2", "user2@mail.com", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "user 2", 2, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "header 3", "text 3", "user3@mail.com", new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified), "user 3", 3, new DateTime(2021, 3, 20, 5, 21, 32, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PostTagMap",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMap_TagId",
                table: "PostTagMap",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTagMap");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
