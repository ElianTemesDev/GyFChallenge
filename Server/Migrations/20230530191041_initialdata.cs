using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class initialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UploadDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Price", "UploadDate" },
                values: new object[,]
                {
                    { 1, "PRODUNO", 10, "30/05/2023 04:10 PM" },
                    { 2, "PRODUNO", 50, "30/05/2023 04:10 PM" },
                    { 3, "PRODUNO", 100, "30/05/2023 04:10 PM" },
                    { 4, "PRODUNO", 110, "30/05/2023 04:10 PM" },
                    { 5, "PRODUNO", 150, "30/05/2023 04:10 PM" },
                    { 6, "PRODUNO", 170, "30/05/2023 04:10 PM" },
                    { 7, "PRODUNO", 200, "30/05/2023 04:10 PM" },
                    { 8, "PRODUNO", 230, "30/05/2023 04:10 PM" },
                    { 9, "PRODUNO", 250, "30/05/2023 04:10 PM" },
                    { 10, "PRODUNO", 300, "30/05/2023 04:10 PM" },
                    { 11, "PRODUNO", 320, "30/05/2023 04:10 PM" },
                    { 12, "PRODUNO", 350, "30/05/2023 04:10 PM" },
                    { 13, "PRODUNO", 400, "30/05/2023 04:10 PM" },
                    { 14, "PRODUNO", 430, "30/05/2023 04:10 PM" },
                    { 15, "PRODUNO", 450, "30/05/2023 04:10 PM" },
                    { 16, "PRODUNO", 500, "30/05/2023 04:10 PM" },
                    { 17, "PRODDOS", 10, "30/05/2023 04:10 PM" },
                    { 18, "PRODDOS", 50, "30/05/2023 04:10 PM" },
                    { 19, "PRODDOS", 100, "30/05/2023 04:10 PM" },
                    { 20, "PRODDOS", 110, "30/05/2023 04:10 PM" },
                    { 21, "PRODDOS", 150, "30/05/2023 04:10 PM" },
                    { 22, "PRODDOS", 170, "30/05/2023 04:10 PM" },
                    { 23, "PRODDOS", 200, "30/05/2023 04:10 PM" },
                    { 24, "PRODDOS", 230, "30/05/2023 04:10 PM" },
                    { 25, "PRODDOS", 250, "30/05/2023 04:10 PM" },
                    { 26, "PRODDOS", 300, "30/05/2023 04:10 PM" },
                    { 27, "PRODDOS", 320, "30/05/2023 04:10 PM" },
                    { 28, "PRODDOS", 350, "30/05/2023 04:10 PM" },
                    { 29, "PRODDOS", 400, "30/05/2023 04:10 PM" },
                    { 30, "PRODDOS", 430, "30/05/2023 04:10 PM" },
                    { 31, "PRODDOS", 450, "30/05/2023 04:10 PM" },
                    { 32, "PRODDOS", 500, "30/05/2023 04:10 PM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
