using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCoreTutorial.Migrations
{
    public partial class Test_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorUsername = table.Column<string>(maxLength: 50, nullable: false),
                    AuthorEmail = table.Column<string>(maxLength: 50, nullable: false),
                    AuthorPassword = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
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
                    RecordsPerPage = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsTitle = table.Column<string>(maxLength: 150, nullable: false),
                    NewsBody = table.Column<string>(maxLength: 4000, nullable: false),
                    NewsViewCount = table.Column<int>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AuthorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                    table.ForeignKey(
                        name: "FK_News_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentBody = table.Column<string>(nullable: true),
                    NewsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagNews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewsID = table.Column<int>(nullable: false),
                    TagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagNews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TagNews_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "AuthorEmail", "AuthorPassword", "AuthorUsername" },
                values: new object[,]
                {
                    { 1, "J.Blair@gmail.co", "2bbamu5x", "AvaOsborne" },
                    { 4, "Isaac.Burrows@sky.info", "8rx7d9yb", "TristanJones" },
                    { 2, "Ava.Hooper@cnn.co.uk", "ot04r6h3", "ChaseWeaver" },
                    { 5, "Hunter.Thomas@yelp.co.uk", "j9jtwiaa", "PiperGiles" },
                    { 3, "Joshua.Hilton@163.info", "u6mnz2pn", "BentleyStuart" },
                    { 6, "Aaliyah.White@deviantart.net", "p2r0ps81", "NathanielHooper" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "CategoryDescription for the CategoryID1", "Category for the NewsID1" },
                    { 4, "CategoryDescription for the CategoryID4", "Category for the NewsID4" },
                    { 2, "CategoryDescription for the CategoryID2", "Category for the NewsID2" },
                    { 5, "CategoryDescription for the CategoryID5", "Category for the NewsID5" },
                    { 3, "CategoryDescription for the CategoryID3", "Category for the NewsID3" },
                    { 6, "CategoryDescription for the CategoryID6", "Category for the NewsID6" }
                });

            migrationBuilder.InsertData(
                table: "Config",
                columns: new[] { "ID", "Description", "Keywords", "RecordsPerPage", "WebSiteAddress" },
                values: new object[] { 1, "lorem ipsum", "keyword,keyword2", 10, "http://localhost" });

            migrationBuilder.InsertData(
                table: "NewsCategories",
                columns: new[] { "ID", "CategoryID", "NewsID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 4, 4 },
                    { 2, 2, 2 },
                    { 5, 5, 5 },
                    { 3, 3, 3 },
                    { 6, 6, 6 }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Tag" },
                values: new object[,]
                {
                    { 1, "Tag for the News 1" },
                    { 4, "Tag for the News 4" },
                    { 2, "Tag for the News 2" },
                    { 5, "Tag for the News 5" },
                    { 3, "Tag for the News 3" },
                    { 6, "Tag for the News 6" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "ID", "AuthorID", "ImageURL", "IsActive", "NewsBody", "NewsTitle", "NewsViewCount", "PublishDate" },
                values: new object[,]
                {
                    { 1, 1, "blog-19.jpg", true, "Maecenas tincidunt leo id nibh vestibulum, in feugiat justo varius.", "Duis gravida erat et euismod consequat.", 9, new DateTime(1989, 12, 16, 0, 35, 27, 851, DateTimeKind.Unspecified).AddTicks(7692) },
                    { 4, 4, "blog-19.jpg", true, "Praesent id magna sed massa hendrerit pellentesque ut quis enim.", "Sed dignissim augue eget orci vulputate, a pellentesque odio facilisis.", 3, new DateTime(1986, 6, 17, 17, 31, 4, 36, DateTimeKind.Unspecified).AddTicks(9658) },
                    { 2, 2, "blog-19.jpg", true, "Phasellus non ante non lectus ullamcorper faucibus id a eros.", "Curabitur sed lorem a dui consequat congue.", 4, new DateTime(1988, 11, 21, 22, 54, 32, 510, DateTimeKind.Unspecified).AddTicks(5019) },
                    { 5, 5, "blog-19.jpg", true, "Morbi sit amet nibh eget eros tempor mollis vel nec lacus.", "Fusce sollicitudin magna ut risus ullamcorper, ut ullamcorper elit adipiscing.", 3, new DateTime(1994, 12, 7, 23, 21, 8, 345, DateTimeKind.Unspecified).AddTicks(4607) },
                    { 3, 3, "blog-19.jpg", true, "Curabitur sed lorem a dui consequat congue.", "Nunc ac sem quis augue pharetra volutpat.", 6, new DateTime(1994, 9, 21, 10, 35, 15, 94, DateTimeKind.Unspecified).AddTicks(1488) },
                    { 6, 6, "blog-19.jpg", true, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "Nullam et tellus posuere, consectetur ante eget, iaculis lorem.", 7, new DateTime(1976, 8, 5, 8, 19, 12, 966, DateTimeKind.Unspecified).AddTicks(1752) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentBody", "NewsID" },
                values: new object[,]
                {
                    { 1, "Curabitur imperdiet dolor eget volutpat ultrices.", 1 },
                    { 2, "Nunc ac ipsum sed purus consectetur sodales.", 2 },
                    { 3, "Vestibulum in enim nec eros faucibus elementum sed vitae dolor.", 3 }
                });

            migrationBuilder.InsertData(
                table: "TagNews",
                columns: new[] { "ID", "NewsID", "TagID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 4, 4, 4 },
                    { 2, 2, 2 },
                    { 5, 5, 5 },
                    { 3, 3, 3 },
                    { 6, 6, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsID",
                table: "Comments",
                column: "NewsID");

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorID",
                table: "News",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_TagNews_NewsID",
                table: "TagNews",
                column: "NewsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "TagNews");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
