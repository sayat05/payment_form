using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentForm.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PhoneNumber",
                value: "1111111");

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PhoneNumber",
                value: "2222222");

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PhoneNumber",
                value: "3333333");

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 4L,
                column: "PhoneNumber",
                value: "44444444");

            migrationBuilder.UpdateData(
                table: "payments",
                keyColumn: "Id",
                keyValue: 5L,
                column: "PhoneNumber",
                value: "5555555");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "payments");
        }
    }
}
