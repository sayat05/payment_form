using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentForm.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class WithoutDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 47, 0, 742, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 47, 0, 742, DateTimeKind.Utc).AddTicks(7034));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 47, 0, 742, DateTimeKind.Utc).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 47, 0, 742, DateTimeKind.Utc).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 47, 0, 742, DateTimeKind.Utc).AddTicks(7040));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 35, 43, 126, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 20, 16, 35, 43, 127, DateTimeKind.Utc).AddTicks(56));
        }
    }
}
