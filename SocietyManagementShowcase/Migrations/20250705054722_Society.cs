using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class Society : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SocietyId",
                table: "Wing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocietyId",
                table: "VisitorLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocietyId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonAmenitiesId",
                table: "MaintenanceLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GymId",
                table: "MaintenanceLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SwimmingPoolId",
                table: "MaintenanceLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaterFiltrationSystemId",
                table: "MaintenanceLog",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SocietyId",
                table: "IssueTicketLog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FireFightingSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FireId = table.Column<int>(type: "int", nullable: false),
                    FireSystemEngineId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireFightingSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireFightingSystem_Engine_FireSystemEngineId",
                        column: x => x.FireSystemEngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FireFightingSystem_WaterTank_FireId",
                        column: x => x.FireId,
                        principalTable: "WaterTank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gym",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gym", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterFiltrationSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterFiltrationSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Society",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfWings = table.Column<int>(type: "int", nullable: false),
                    FireSystemId = table.Column<int>(type: "int", nullable: false),
                    WaterFilterId = table.Column<int>(type: "int", nullable: false),
                    IndoorGymId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    TotalFlatAreaSociety = table.Column<double>(type: "float", nullable: false),
                    TotalMaintenanceChargeSociety = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Society", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Society_FireFightingSystem_FireSystemId",
                        column: x => x.FireSystemId,
                        principalTable: "FireFightingSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Society_Gym_IndoorGymId",
                        column: x => x.IndoorGymId,
                        principalTable: "Gym",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Society_WaterFiltrationSystem_WaterFilterId",
                        column: x => x.WaterFilterId,
                        principalTable: "WaterFiltrationSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommonAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonAmenities_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SwimmingPool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Health = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false),
                    PoolType = table.Column<int>(type: "int", nullable: false),
                    SocietyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingPool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwimmingPool_Society_SocietyId",
                        column: x => x.SocietyId,
                        principalTable: "Society",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wing_SocietyId",
                table: "Wing",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLog_SocietyId",
                table: "VisitorLog",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SocietyId",
                table: "Person",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_CommonAmenitiesId",
                table: "MaintenanceLog",
                column: "CommonAmenitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_GymId",
                table: "MaintenanceLog",
                column: "GymId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_SwimmingPoolId",
                table: "MaintenanceLog",
                column: "SwimmingPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_WaterFiltrationSystemId",
                table: "MaintenanceLog",
                column: "WaterFiltrationSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTicketLog_SocietyId",
                table: "IssueTicketLog",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonAmenities_SocietyId",
                table: "CommonAmenities",
                column: "SocietyId");

            migrationBuilder.CreateIndex(
                name: "IX_FireFightingSystem_FireId",
                table: "FireFightingSystem",
                column: "FireId");

            migrationBuilder.CreateIndex(
                name: "IX_FireFightingSystem_FireSystemEngineId",
                table: "FireFightingSystem",
                column: "FireSystemEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_FireSystemId",
                table: "Society",
                column: "FireSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_IndoorGymId",
                table: "Society",
                column: "IndoorGymId");

            migrationBuilder.CreateIndex(
                name: "IX_Society_WaterFilterId",
                table: "Society",
                column: "WaterFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_SwimmingPool_SocietyId",
                table: "SwimmingPool",
                column: "SocietyId");

            migrationBuilder.AddForeignKey(
                name: "FK_IssueTicketLog_Society_SocietyId",
                table: "IssueTicketLog",
                column: "SocietyId",
                principalTable: "Society",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_CommonAmenities_CommonAmenitiesId",
                table: "MaintenanceLog",
                column: "CommonAmenitiesId",
                principalTable: "CommonAmenities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_Gym_GymId",
                table: "MaintenanceLog",
                column: "GymId",
                principalTable: "Gym",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_SwimmingPool_SwimmingPoolId",
                table: "MaintenanceLog",
                column: "SwimmingPoolId",
                principalTable: "SwimmingPool",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_WaterFiltrationSystem_WaterFiltrationSystemId",
                table: "MaintenanceLog",
                column: "WaterFiltrationSystemId",
                principalTable: "WaterFiltrationSystem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Society_SocietyId",
                table: "Person",
                column: "SocietyId",
                principalTable: "Society",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorLog_Society_SocietyId",
                table: "VisitorLog",
                column: "SocietyId",
                principalTable: "Society",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wing_Society_SocietyId",
                table: "Wing",
                column: "SocietyId",
                principalTable: "Society",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssueTicketLog_Society_SocietyId",
                table: "IssueTicketLog");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_CommonAmenities_CommonAmenitiesId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_Gym_GymId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_SwimmingPool_SwimmingPoolId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_WaterFiltrationSystem_WaterFiltrationSystemId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Society_SocietyId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorLog_Society_SocietyId",
                table: "VisitorLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Wing_Society_SocietyId",
                table: "Wing");

            migrationBuilder.DropTable(
                name: "CommonAmenities");

            migrationBuilder.DropTable(
                name: "SwimmingPool");

            migrationBuilder.DropTable(
                name: "Society");

            migrationBuilder.DropTable(
                name: "FireFightingSystem");

            migrationBuilder.DropTable(
                name: "Gym");

            migrationBuilder.DropTable(
                name: "WaterFiltrationSystem");

            migrationBuilder.DropIndex(
                name: "IX_Wing_SocietyId",
                table: "Wing");

            migrationBuilder.DropIndex(
                name: "IX_VisitorLog_SocietyId",
                table: "VisitorLog");

            migrationBuilder.DropIndex(
                name: "IX_Person_SocietyId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceLog_CommonAmenitiesId",
                table: "MaintenanceLog");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceLog_GymId",
                table: "MaintenanceLog");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceLog_SwimmingPoolId",
                table: "MaintenanceLog");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceLog_WaterFiltrationSystemId",
                table: "MaintenanceLog");

            migrationBuilder.DropIndex(
                name: "IX_IssueTicketLog_SocietyId",
                table: "IssueTicketLog");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                table: "Wing");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                table: "VisitorLog");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "CommonAmenitiesId",
                table: "MaintenanceLog");

            migrationBuilder.DropColumn(
                name: "GymId",
                table: "MaintenanceLog");

            migrationBuilder.DropColumn(
                name: "SwimmingPoolId",
                table: "MaintenanceLog");

            migrationBuilder.DropColumn(
                name: "WaterFiltrationSystemId",
                table: "MaintenanceLog");

            migrationBuilder.DropColumn(
                name: "SocietyId",
                table: "IssueTicketLog");
        }
    }
}
