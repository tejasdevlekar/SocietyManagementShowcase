using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocietyManagementShowcase.Migrations
{
    /// <inheritdoc />
    public partial class addingSociety : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireFightingSystems_Engine_FireSystemEngineId",
                table: "FireFightingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_FireFightingSystems_WaterTanks_FireId",
                table: "FireFightingSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_WaterTanks_WaterTankId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Society_FireFightingSystems_FireSystemId",
                table: "Society");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterTanks_Wing_WingId",
                table: "WaterTanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterTanks",
                table: "WaterTanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FireFightingSystems",
                table: "FireFightingSystems");

            migrationBuilder.RenameTable(
                name: "WaterTanks",
                newName: "WaterTank");

            migrationBuilder.RenameTable(
                name: "FireFightingSystems",
                newName: "FireFightingSystem");

            migrationBuilder.RenameIndex(
                name: "IX_WaterTanks_WingId",
                table: "WaterTank",
                newName: "IX_WaterTank_WingId");

            migrationBuilder.RenameIndex(
                name: "IX_FireFightingSystems_FireSystemEngineId",
                table: "FireFightingSystem",
                newName: "IX_FireFightingSystem_FireSystemEngineId");

            migrationBuilder.RenameIndex(
                name: "IX_FireFightingSystems_FireId",
                table: "FireFightingSystem",
                newName: "IX_FireFightingSystem_FireId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastMaintenanceCheck",
                table: "WaterFiltrationSystem",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterTank",
                table: "WaterTank",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FireFightingSystem",
                table: "FireFightingSystem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FireFightingSystem_Engine_FireSystemEngineId",
                table: "FireFightingSystem",
                column: "FireSystemEngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireFightingSystem_WaterTank_FireId",
                table: "FireFightingSystem",
                column: "FireId",
                principalTable: "WaterTank",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_WaterTank_WaterTankId",
                table: "MaintenanceLog",
                column: "WaterTankId",
                principalTable: "WaterTank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Society_FireFightingSystem_FireSystemId",
                table: "Society",
                column: "FireSystemId",
                principalTable: "FireFightingSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterTank_Wing_WingId",
                table: "WaterTank",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FireFightingSystem_Engine_FireSystemEngineId",
                table: "FireFightingSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_FireFightingSystem_WaterTank_FireId",
                table: "FireFightingSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceLog_WaterTank_WaterTankId",
                table: "MaintenanceLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Society_FireFightingSystem_FireSystemId",
                table: "Society");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterTank_Wing_WingId",
                table: "WaterTank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaterTank",
                table: "WaterTank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FireFightingSystem",
                table: "FireFightingSystem");

            migrationBuilder.RenameTable(
                name: "WaterTank",
                newName: "WaterTanks");

            migrationBuilder.RenameTable(
                name: "FireFightingSystem",
                newName: "FireFightingSystems");

            migrationBuilder.RenameIndex(
                name: "IX_WaterTank_WingId",
                table: "WaterTanks",
                newName: "IX_WaterTanks_WingId");

            migrationBuilder.RenameIndex(
                name: "IX_FireFightingSystem_FireSystemEngineId",
                table: "FireFightingSystems",
                newName: "IX_FireFightingSystems_FireSystemEngineId");

            migrationBuilder.RenameIndex(
                name: "IX_FireFightingSystem_FireId",
                table: "FireFightingSystems",
                newName: "IX_FireFightingSystems_FireId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastMaintenanceCheck",
                table: "WaterFiltrationSystem",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaterTanks",
                table: "WaterTanks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FireFightingSystems",
                table: "FireFightingSystems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FireFightingSystems_Engine_FireSystemEngineId",
                table: "FireFightingSystems",
                column: "FireSystemEngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireFightingSystems_WaterTanks_FireId",
                table: "FireFightingSystems",
                column: "FireId",
                principalTable: "WaterTanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceLog_WaterTanks_WaterTankId",
                table: "MaintenanceLog",
                column: "WaterTankId",
                principalTable: "WaterTanks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Society_FireFightingSystems_FireSystemId",
                table: "Society",
                column: "FireSystemId",
                principalTable: "FireFightingSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterTanks_Wing_WingId",
                table: "WaterTanks",
                column: "WingId",
                principalTable: "Wing",
                principalColumn: "Id");
        }
    }
}
