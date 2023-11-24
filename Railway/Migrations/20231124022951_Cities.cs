using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway.Migrations
{
    /// <inheritdoc />
    public partial class Cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubName",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubName",
                table: "City");
        }
    }
}
