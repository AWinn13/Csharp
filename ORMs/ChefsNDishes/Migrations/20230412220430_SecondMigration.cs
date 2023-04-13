using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChefsNDishes.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Chefs_CreatorUserId",
                table: "Dish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.DropIndex(
                name: "IX_Dish_CreatorUserId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Dish");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Chefs",
                newName: "ChefId");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameColumn(
                name: "ChefId",
                table: "Chefs",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "CreatorUserId",
                table: "Dish",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dish",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dish_CreatorUserId",
                table: "Dish",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Chefs_CreatorUserId",
                table: "Dish",
                column: "CreatorUserId",
                principalTable: "Chefs",
                principalColumn: "UserId");
        }
    }
}
