using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Railway.Migrations
{
    /// <inheritdoc />
    public partial class TrainsController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DOA",
                table: "Train",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "Login",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOA",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Login");
        }
    }
}
