using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxifer.Migrations
{
    /// <inheritdoc />
    public partial class associacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Luminarias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Luminarias_UserId",
                table: "Luminarias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Luminarias_Users_UserId",
                table: "Luminarias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luminarias_Users_UserId",
                table: "Luminarias");

            migrationBuilder.DropIndex(
                name: "IX_Luminarias_UserId",
                table: "Luminarias");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Luminarias");
        }
    }
}
