using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server_API.Migrations
{
    public partial class AddStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentStatus",
                table: "PaymentBills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "NOTPAID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "PaymentBills");
        }
    }
}
