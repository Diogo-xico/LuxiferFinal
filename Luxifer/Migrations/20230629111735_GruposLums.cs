using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Luxifer.Migrations
{
    /// <inheritdoc />
    public partial class GruposLums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrupoId",
                table: "Luminarias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cor = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Luminarias_GrupoId",
                table: "Luminarias",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupo_UserId",
                table: "Grupo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Luminarias_Grupo_GrupoId",
                table: "Luminarias",
                column: "GrupoId",
                principalTable: "Grupo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Luminarias_Grupo_GrupoId",
                table: "Luminarias");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropIndex(
                name: "IX_Luminarias_GrupoId",
                table: "Luminarias");

            migrationBuilder.DropColumn(
                name: "GrupoId",
                table: "Luminarias");
        }
    }
}
