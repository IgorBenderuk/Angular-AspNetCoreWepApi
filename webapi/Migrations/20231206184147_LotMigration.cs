using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class LotMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lots_OwnerId",
                table: "Lots",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_Users_OwnerId",
                table: "Lots",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lots_Users_OwnerId",
                table: "Lots");

            migrationBuilder.DropIndex(
                name: "IX_Lots_OwnerId",
                table: "Lots");
        }
    }
}
