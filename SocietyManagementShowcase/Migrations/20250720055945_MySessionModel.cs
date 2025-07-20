using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class MySessionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MySessionModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ExpiresAtTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlidingExpirationInSeconds = table.Column<double>(type: "float", nullable: false),
                    AbsoluteExpiration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySessionModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MySessionModel");
        }
    }
}
