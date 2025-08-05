using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SubscriptionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "Id", "EndDate", "StartDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2099, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 5, 17, 15, 28, 19, 0, DateTimeKind.Utc), "Free" },
                    { 2, new DateTime(2022, 8, 18, 15, 28, 19, 0, DateTimeKind.Utc), new DateTime(2022, 5, 18, 15, 28, 19, 0, DateTimeKind.Utc), "Super" },
                    { 3, new DateTime(2022, 6, 19, 15, 28, 19, 0, DateTimeKind.Utc), new DateTime(2022, 5, 19, 15, 28, 19, 0, DateTimeKind.Utc), "Trial" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Name", "SubscriptionId" },
                values: new object[,]
                {
                    { 1, "John@example.com", "John Doe", 2 },
                    { 2, "Mark@example.com", "Mark Shimko", 1 },
                    { 3, "Taras@example.com", "Taras Ovruch", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_SubscriptionId",
                table: "users",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "subscriptions");
        }
    }
}
