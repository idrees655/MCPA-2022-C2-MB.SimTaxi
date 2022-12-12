using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MB.SimTaxi.Mvc.Data.Migrations
{
    public partial class car_plateNumber_unique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_PlateNumber",
                table: "Cars",
                column: "PlateNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cars_PlateNumber",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "PlateNumber",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
