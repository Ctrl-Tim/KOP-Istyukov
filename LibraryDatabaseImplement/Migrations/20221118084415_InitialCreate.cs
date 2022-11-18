using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reader6 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Shapes");
        }
    }
}
