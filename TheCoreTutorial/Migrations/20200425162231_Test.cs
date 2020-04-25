using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCoreTutorial.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorUsername = table.Column<string>(maxLength: 50, nullable: false),
                    AuthorEmail = table.Column<string>(maxLength: 50, nullable: false),
                    AuthorPassword = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentBody = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebSiteAddress = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Keywords = table.Column<string>(maxLength: 500, nullable: true),
                    RecordsPerPage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(maxLength: 150, nullable: false),
                    NewsBody = table.Column<string>(maxLength: 4000, nullable: false),
                    NewsViewCount = table.Column<int>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "AuthorNew",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    AuthorID = table.Column<int>(nullable: false),
                    AuthorsAuthorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorNew", x => new { x.NewsID, x.AuthorID });
                    table.ForeignKey(
                        name: "FK_AuthorNew_Authors_AuthorsAuthorID",
                        column: x => x.AuthorsAuthorID,
                        principalTable: "Authors",
                        principalColumn: "AuthorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorNew_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentNews",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false),
                    NewsID = table.Column<int>(nullable: false),
                    CommentsCommentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentNews", x => new { x.NewsID, x.CommentID });
                    table.ForeignKey(
                        name: "FK_CommentNews_Comments_CommentsCommentID",
                        column: x => x.CommentsCommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentNews_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    CategoriesCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => new { x.NewsID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_NewsCategories_Categories_CategoriesCategoryID",
                        column: x => x.CategoriesCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsCategories_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagNews",
                columns: table => new
                {
                    NewsID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false),
                    TagsTagID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNews", x => new { x.NewsID, x.TagID });
                    table.ForeignKey(
                        name: "FK_TagNews_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "NewsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagNews_Tags_TagsTagID",
                        column: x => x.TagsTagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorID", "AuthorEmail", "AuthorPassword", "AuthorUsername" },
                values: new object[,]
                {
                    { 1, "Hailey.Adam@taobao.co.uk", "t166hmg3", "LeahKenny" },
                    { 2, "A.Sanders@amazon.co.uk", "4ffpr6m7", "BellaGreen" },
                    { 3, "Liam.Mclean@bbc.org.uk", "qo9ksupk", "LeahAkhtar" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Nunc iaculis metus a tristique adipiscing.", "yrxiy77cbfzwej04s2kb" },
                    { 2, "Pellentesque commodo risus vitae orci pretium tincidunt.", "hy0rgtjvvov1m9z6xp9u" },
                    { 3, "Fusce scelerisque sapien ornare neque pharetra aliquam.", "78nhsi6pcemutox4iskr" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentBody" },
                values: new object[,]
                {
                    { 1, "Vivamus scelerisque felis sed nisl feugiat, mattis consequat lacus pulvinar." },
                    { 2, "Integer eu neque at lectus imperdiet tincidunt." },
                    { 3, "In laoreet justo et condimentum bibendum." }
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "ID", "Description", "Keywords", "RecordsPerPage", "WebSiteAddress" },
                values: new object[] { 1, "lorem ipsum", "keyword,keyword2", 10, "http://localhost" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "NewsID", "ImageURL", "IsActive", "NewsBody", "NewsTitle", "NewsViewCount", "PublishDate" },
                values: new object[,]
                {
                    { 1, "theguardian.co", true, "Morbi sit amet libero vitae augue porttitor tempus.", "Nunc ac sem quis augue pharetra volutpat.", 2, new DateTime(1986, 12, 5, 15, 57, 37, 474, DateTimeKind.Unspecified).AddTicks(5647) },
                    { 2, "yahoo.info", true, "Donec dignissim massa nec urna porttitor facilisis.", "Donec interdum velit a orci consectetur, non mollis diam hendrerit.", 8, new DateTime(1990, 12, 15, 9, 55, 40, 941, DateTimeKind.Unspecified).AddTicks(2020) },
                    { 3, "stackoverflow.com", true, "Curabitur imperdiet dolor eget volutpat ultrices.", "Nulla a ligula laoreet, viverra purus vel, suscipit enim.", 7, new DateTime(1979, 11, 10, 6, 24, 6, 495, DateTimeKind.Unspecified).AddTicks(8641) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagID", "Tag" },
                values: new object[,]
                {
                    { 1, "amsjiism" },
                    { 2, "mfggcemg" },
                    { 3, "fhsjosuy" }
                });

            migrationBuilder.InsertData(
                table: "AuthorNew",
                columns: new[] { "NewsID", "AuthorID", "AuthorsAuthorID" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "CommentNews",
                columns: new[] { "NewsID", "CommentID", "CommentsCommentID" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "NewsID", "CategoryID", "CategoriesCategoryID" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null }
                });

            migrationBuilder.InsertData(
                table: "TagNews",
                columns: new[] { "NewsID", "TagID", "TagsTagID" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 2, null },
                    { 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorNew_AuthorsAuthorID",
                table: "AuthorNew",
                column: "AuthorsAuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentNews_CommentsCommentID",
                table: "CommentNews",
                column: "CommentsCommentID");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategories_CategoriesCategoryID",
                table: "NewsCategories",
                column: "CategoriesCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_TagNews_TagsTagID",
                table: "TagNews",
                column: "TagsTagID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorNew");

            migrationBuilder.DropTable(
                name: "CommentNews");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "TagNews");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
