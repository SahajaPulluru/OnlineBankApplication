using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Atmdtls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Atmpin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Atmdtls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_checkbookdtls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_checkbookdtls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_FundTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceAccNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestAccNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestAccTypeID = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TransferAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_FundTransfer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Users",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountTypeId = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Users", x => x.AccountNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Atmdtls");

            migrationBuilder.DropTable(
                name: "Tbl_checkbookdtls");

            migrationBuilder.DropTable(
                name: "Tbl_FundTransfer");

            migrationBuilder.DropTable(
                name: "Tbl_Transactions");

            migrationBuilder.DropTable(
                name: "Tbl_Users");
        }
    }
}
