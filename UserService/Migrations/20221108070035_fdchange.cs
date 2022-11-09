using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    /// <inheritdoc />
    public partial class fdchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FixedDeposits",
                table: "FixedDeposits");

            migrationBuilder.RenameTable(
                name: "FixedDeposits",
                newName: "Tbl_FixedDeposits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_FixedDeposits",
                table: "Tbl_FixedDeposits",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_FixedDeposits",
                table: "Tbl_FixedDeposits");

            migrationBuilder.RenameTable(
                name: "Tbl_FixedDeposits",
                newName: "FixedDeposits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FixedDeposits",
                table: "FixedDeposits",
                column: "Id");
        }
    }
}
