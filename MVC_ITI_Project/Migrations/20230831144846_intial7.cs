using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ITI_Project.Migrations
{
    /// <inheritdoc />
    public partial class intial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
