using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IKEA.DAL.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employee");
        }
    }
}
