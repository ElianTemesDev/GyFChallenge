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
                    { 1, "PRODUNO", 150, "29/05/2023 11:48 PM" },
                    { 2, "PRODUNO", 180, "29/05/2023 11:48 PM" },
                    { 3, "PRODUNO", 15, "29/05/2023 11:48 PM" },
                    { 4, "PRODUNO", 20, "29/05/2023 11:48 PM" },
                    { 5, "PRODDOS", 250, "29/05/2023 11:48 PM" },
                    { 6, "PRODDOS", 500, "29/05/2023 11:48 PM" },
                    { 7, "PRODDOS", 5, "29/05/2023 11:48 PM" },
                    { 8, "PRODDOS", 800, "29/05/2023 11:48 PM" }
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
