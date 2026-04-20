using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentForm.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WalletNumber = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wallets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wallets_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WalletId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payments_wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "wallets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1L, "user_1@u", "user_1", "555-111-3333" },
                    { 2L, "user_2@u", "user_2", "" },
                    { 3L, "user_3@u", "user_3", "123-123-1234" },
                    { 4L, "user_4@u", "user_4", "" }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "Id", "Balance", "UserId", "WalletNumber" },
                values: new object[,]
                {
                    { 1L, 1235m, 1L, "1111" },
                    { 2L, 9876m, 1L, "2222" },
                    { 3L, 4567m, 2L, "3333" },
                    { 4L, 1234m, 3L, "4444" },
                    { 5L, 5432m, 4L, "5555" },
                    { 6L, 7687m, 4L, "6666" }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "Id", "Amount", "Comment", "CreatedAt", "Currency", "Email", "Status", "WalletId" },
                values: new object[,]
                {
                    { 1L, 123m, "", new DateTime(2026, 4, 20, 16, 35, 43, 126, DateTimeKind.Utc).AddTicks(8019), 1, "user_1@u", 0, 1L },
                    { 2L, 1000m, "", new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(30), 3, "user_1@u", 0, 2L },
                    { 3L, 123m, "", new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(34), 1, "user_2@u", 0, 3L },
                    { 4L, 765m, "", new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(53), 2, "user_3@u", 0, 4L },
                    { 5L, 5000m, "", new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(56), 4, "user_4@u", 0, 6L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_WalletId",
                table: "payments",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_wallets_UserId",
                table: "wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_WalletNumber",
                table: "wallets",
                column: "WalletNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
