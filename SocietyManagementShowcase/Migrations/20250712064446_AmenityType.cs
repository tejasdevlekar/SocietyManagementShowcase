using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class AmenityType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmenityType",
                table: "SwimmingPool",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmenityType",
                table: "Gym",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmenityType",
                table: "CommonAmenities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmenityType",
                table: "SwimmingPool");

            migrationBuilder.DropColumn(
                name: "AmenityType",
                table: "Gym");

            migrationBuilder.DropColumn(
                name: "AmenityType",
                table: "CommonAmenities");
        }
    }
}
