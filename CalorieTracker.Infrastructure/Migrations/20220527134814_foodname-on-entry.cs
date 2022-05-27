using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTracker.Infrastructure.Migrations
{
    public partial class foodnameonentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "CalorieEntry",
                newName: "FoodTypeName");

            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "CalorieEntry",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FoodTypeName",
                table: "CalorieEntry",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "CalorieEntry",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
