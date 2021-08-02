using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.ASB.CreditCardStore.InfraStructure.Migrations.DomainMigrations
{
    public partial class InitialDomainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardHolders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CardHolderName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardHolders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreditCardNumber = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CVC = table.Column<string>(maxLength: 10, nullable: true),
                    CardHolderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_CardHolders_CardHolderId",
                        column: x => x.CardHolderId,
                        principalTable: "CardHolders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CardHolderId",
                table: "CreditCards",
                column: "CardHolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "CardHolders");
        }
    }
}
