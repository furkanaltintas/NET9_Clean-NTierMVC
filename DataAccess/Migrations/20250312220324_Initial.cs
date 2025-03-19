using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPublish = table.Column<bool>(type: "bit", nullable: false),
                    IsTrash = table.Column<bool>(type: "bit", nullable: false),
                    LitterBoxTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.CheckConstraint("CK_Skill_Point", "[Point] BETWEEN 0 AND 100");
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaIcons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaIcons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfEmployments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfEmployments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvLink = table.Column<byte[]>(type: "varbinary(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebSiteInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebSiteTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Background = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SidebarColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvButtonColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSiteTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioCategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_PortfolioCategories_PortfolioCategoryId",
                        column: x => x.PortfolioCategoryId,
                        principalTable: "PortfolioCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfEmploymentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_TypeOfEmployments_TypeOfEmploymentId",
                        column: x => x.TypeOfEmploymentId,
                        principalTable: "TypeOfEmployments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "Image", "IsPublish", "IsTrash", "LitterBoxTime", "PublishDate", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "title", true, false, 0, new DateTime(2025, 3, 13, 1, 3, 23, 696, DateTimeKind.Local).AddTicks(6624), "title", "Title" },
                    { 2, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "title2", true, false, 0, new DateTime(2025, 3, 13, 1, 3, 23, 698, DateTimeKind.Local).AddTicks(7043), "title-2", "Title 2" },
                    { 3, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "title3", true, false, 0, new DateTime(2025, 3, 13, 1, 3, 23, 698, DateTimeKind.Local).AddTicks(7059), "title-3", "Title3" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "Degree", "Department", "Description", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "Title", "Title", "Title", new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(5814), new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(5580), "Title" },
                    { 2, "Title2", "Title2", "Title2", new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6009), new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6008), "Title2" },
                    { 3, "Title3", "Title3", "Title3", new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6011), new DateTime(2025, 3, 13, 1, 3, 23, 700, DateTimeKind.Local).AddTicks(6011), "Title3" }
                });

            migrationBuilder.InsertData(
                table: "PortfolioCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Test" },
                    { 2, "Test2" },
                    { 3, "Test3" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "Description", "Icon", "Name" },
                    { 2, "Description2", "Icon2", "Name2" },
                    { 3, "Description3", "Icon3", "Name3" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Point" },
                values: new object[,]
                {
                    { 1, "Name", 10 },
                    { 2, "Name2", 20 },
                    { 3, "Name3", 30 },
                    { 4, "Name4", 40 },
                    { 5, "Name5", 50 },
                    { 6, "Name6", 60 },
                    { 7, "Name7", 70 }
                });

            migrationBuilder.InsertData(
                table: "SocialMediaIcons",
                columns: new[] { "Id", "Icon", "Link", "Name" },
                values: new object[,]
                {
                    { 1, "Icon", "Link", "Name" },
                    { 2, "Icon2", "Link2", "Name2" },
                    { 3, "Icon3", "Link3", "Name3" },
                    { 4, "Icon4", "Link4", "Name4" },
                    { 5, "Icon5", "Link5", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfEmployments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sürekli / Tam Zamanlı" },
                    { 2, "Yarı Zamanlı" },
                    { 3, "Stajyer" },
                    { 4, "Dönemsel" },
                    { 5, "Serbest" },
                    { 6, "Gönüllü" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "City", "CvLink", "Email", "FirstName", "LastName", "Password", "Phone", "Profession", "Profile", "UserName" },
                values: new object[] { 1, new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstanbul", null, "furkanaltintas785@gmail.com", "Furkan", "Altıntaş", "1234", "+90 555 555 55 55", "NET DEVELOPER", "frkn", "FRKN" });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Company", "Description", "EndDate", "Location", "StartDate", "Title", "TypeOfEmploymentId" },
                values: new object[,]
                {
                    { 1, "Title", "Title", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(5852), "Title", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(5624), "Title", 1 },
                    { 2, "Title2", "Title2", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6129), "Title2", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6127), "Title2", 2 },
                    { 3, "Title3", "Title3", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6131), "Title3", new DateTime(2025, 3, 13, 1, 3, 23, 705, DateTimeKind.Local).AddTicks(6131), "Title3", 3 }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "Id", "Image", "PortfolioCategoryId", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "image", 1, "title", "Title" },
                    { 2, "image2", 2, "title2", "Title2" },
                    { 3, "image3", 3, "title3", "Title3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_TypeOfEmploymentId",
                table: "Experiences",
                column: "TypeOfEmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_PortfolioCategoryId",
                table: "Portfolios",
                column: "PortfolioCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SocialMediaIcons");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WebSiteInfos");

            migrationBuilder.DropTable(
                name: "WebSiteTemplates");

            migrationBuilder.DropTable(
                name: "TypeOfEmployments");

            migrationBuilder.DropTable(
                name: "PortfolioCategories");
        }
    }
}
