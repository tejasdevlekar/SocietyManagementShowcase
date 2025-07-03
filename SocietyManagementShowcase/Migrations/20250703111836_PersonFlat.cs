using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class PersonFlat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wing",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuelLevel = table.Column<int>(type: "int", nullable: false),
                    OilLevel = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubManagerId = table.Column<int>(type: "int", nullable: false),
                    NoticeBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricMeterReading = table.Column<double>(type: "float", nullable: false),
                    ElectricMeterBill = table.Column<double>(type: "float", nullable: false),
                    TotalFlatAreaWing = table.Column<double>(type: "float", nullable: false),
                    TotalMaintenanceChargeWing = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wing_Person_SubManagerId",
                        column: x => x.SubManagerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityGenerator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WingId = table.Column<int>(type: "int", nullable: false),
                    BackupGeneratorEngineId = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityGenerator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityGenerator_Engine_BackupGeneratorEngineId",
                        column: x => x.BackupGeneratorEngineId,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityGenerator_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Elevator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WingId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elevator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elevator_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WingId = table.Column<int>(type: "int", nullable: false),
                    AreaSqFt = table.Column<float>(type: "real", nullable: false),
                    MaintenanceCharge = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flat_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssueTicketLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTicketLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueTicketLog_Person_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueTicketLog_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VisitorLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Wing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitorLog_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WaterTank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    WaterLevel = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    WingId = table.Column<int>(type: "int", nullable: false),
                    LastMaintenanceCheck = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterTank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterTank_Wing_WingId",
                        column: x => x.WingId,
                        principalTable: "Wing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenaceDoneByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenaceCheckedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: true),
                    WaterTankId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceLog_Engine_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engine",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MaintenanceLog_WaterTank_WaterTankId",
                        column: x => x.WaterTankId,
                        principalTable: "WaterTank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_FlatId",
                table: "Person",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityGenerator_BackupGeneratorEngineId",
                table: "ElectricityGenerator",
                column: "BackupGeneratorEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityGenerator_WingId",
                table: "ElectricityGenerator",
                column: "WingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elevator_WingId",
                table: "Elevator",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_WingId",
                table: "Flat",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTicketLog_CreatedById",
                table: "IssueTicketLog",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_IssueTicketLog_WingId",
                table: "IssueTicketLog",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_EngineId",
                table: "MaintenanceLog",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceLog_WaterTankId",
                table: "MaintenanceLog",
                column: "WaterTankId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorLog_WingId",
                table: "VisitorLog",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterTank_WingId",
                table: "WaterTank",
                column: "WingId");

            migrationBuilder.CreateIndex(
                name: "IX_Wing_SubManagerId",
                table: "Wing",
                column: "SubManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Flat_FlatId",
                table: "Person",
                column: "FlatId",
                principalTable: "Flat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Flat_FlatId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "ElectricityGenerator");

            migrationBuilder.DropTable(
                name: "Elevator");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "IssueTicketLog");

            migrationBuilder.DropTable(
                name: "MaintenanceLog");

            migrationBuilder.DropTable(
                name: "VisitorLog");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "WaterTank");

            migrationBuilder.DropTable(
                name: "Wing");

            migrationBuilder.DropIndex(
                name: "IX_Person_FlatId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Wing",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
