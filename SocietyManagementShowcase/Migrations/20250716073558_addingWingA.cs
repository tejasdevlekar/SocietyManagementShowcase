using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class addingWingA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastMaintenanceCheck",
                table: "Engine",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastMaintenanceCheck",
                table: "Engine",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
