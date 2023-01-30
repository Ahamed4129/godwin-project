using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseOrder.API.Migrations
{
    public partial class ahamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDetails",
                columns: table => new
                {
                    LoginID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDetails", x => x.LoginID);
                });

            migrationBuilder.CreateTable(
                name: "POMaster",
                columns: table => new
                {
                    POID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POMaster", x => x.POID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDetails",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDetails", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemMaster_POMaster_POID",
                        column: x => x.POID,
                        principalTable: "POMaster",
                        principalColumn: "POID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMaster_POID",
                table: "ItemMaster",
                column: "POID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "LoginDetails");

            migrationBuilder.DropTable(
                name: "SupplierDetails");

            migrationBuilder.DropTable(
                name: "POMaster");
        }
    }
}
