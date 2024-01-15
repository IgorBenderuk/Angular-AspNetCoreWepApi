using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class DBSetForUserBank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBank_Banks_BankID",
                table: "UserBank");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBank_Users_UserID",
                table: "UserBank");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBank",
                table: "UserBank");

            migrationBuilder.RenameTable(
                name: "UserBank",
                newName: "UserBanks");

            migrationBuilder.RenameIndex(
                name: "IX_UserBank_BankID",
                table: "UserBanks",
                newName: "IX_UserBanks_BankID");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "UserBanks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBanks",
                table: "UserBanks",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_UserBanks_UserID",
                table: "UserBanks",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBanks_Banks_BankID",
                table: "UserBanks",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBanks_Users_UserID",
                table: "UserBanks",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBanks_Banks_BankID",
                table: "UserBanks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBanks_Users_UserID",
                table: "UserBanks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserBanks",
                table: "UserBanks");

            migrationBuilder.DropIndex(
                name: "IX_UserBanks_UserID",
                table: "UserBanks");

            migrationBuilder.RenameTable(
                name: "UserBanks",
                newName: "UserBank");

            migrationBuilder.RenameIndex(
                name: "IX_UserBanks_BankID",
                table: "UserBank",
                newName: "IX_UserBank_BankID");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "UserBank",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserBank",
                table: "UserBank",
                columns: new[] { "UserID", "BankID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserBank_Banks_BankID",
                table: "UserBank",
                column: "BankID",
                principalTable: "Banks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserBank_Users_UserID",
                table: "UserBank",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
