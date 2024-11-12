using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    NIP = table.Column<string>(type: "TEXT", nullable: false),
                    REGON = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Adress_City", "Adress_Street", "NIP", "Name", "REGON" },
                values: new object[,]
                {
                    { 101, "Krkaow", "sw. Filipa", "32354624", "WSEI", "23234523442" },
                    { 102, "Warszawa", "Dworcowa 8", "32354624", "PKP", "23234523442" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "BirthDate", "Category", "Created", "Email", "FirstName", "LastName", "OrganizationId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 12, 17, 39, 32, 100, DateTimeKind.Local).AddTicks(7561), "adad@gmail.com", "Adam", "Kowalski", 101, "123456234" },
                    { 2, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 12, 17, 39, 32, 100, DateTimeKind.Local).AddTicks(7612), "robert@gmail.com", "Robert", "Kowal", 102, "123742684" },
                    { 3, new DateOnly(2000, 10, 10), 0, new DateTime(2024, 11, 12, 17, 39, 32, 100, DateTimeKind.Local).AddTicks(7615), "robert@gmail.com", "Robert", "Kowal", 101, "124963748" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_OrganizationId",
                table: "Contacts",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "organizations");
        }
    }
}
