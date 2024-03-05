using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class TrampolineNameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Trampoline_TrampolineId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trampoline",
                table: "Trampoline");

            migrationBuilder.RenameTable(
                name: "Trampoline",
                newName: "Trampolines");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trampolines",
                table: "Trampolines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Trampolines_TrampolineId",
                table: "Orders",
                column: "TrampolineId",
                principalTable: "Trampolines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Trampolines_TrampolineId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trampolines",
                table: "Trampolines");

            migrationBuilder.RenameTable(
                name: "Trampolines",
                newName: "Trampoline");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trampoline",
                table: "Trampoline",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Trampoline_TrampolineId",
                table: "Orders",
                column: "TrampolineId",
                principalTable: "Trampoline",
                principalColumn: "Id");
        }
    }
}
