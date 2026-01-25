using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlantInfoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ActualYieldQuantity",
                table: "Crops",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YieldUnit",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ActivityType",
                table: "CropActivityLogs",
                type: "int",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<Guid>(
                name: "PerformedById",
                table: "CropActivityLogs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CropActivityLogs_PerformedById",
                table: "CropActivityLogs",
                column: "PerformedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CropActivityLogs_Users_PerformedById",
                table: "CropActivityLogs",
                column: "PerformedById",
                principalSchema: "security",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CropActivityLogs_Users_PerformedById",
                table: "CropActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_CropActivityLogs_PerformedById",
                table: "CropActivityLogs");

            migrationBuilder.DropColumn(
                name: "ActualYieldQuantity",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "YieldUnit",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "PerformedById",
                table: "CropActivityLogs");

            migrationBuilder.AlterColumn<string>(
                name: "ActivityType",
                table: "CropActivityLogs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100);
        }
    }
}
