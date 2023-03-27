using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class orderStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChiefOrder",
                table: "Order",
                newName: "ChiefOrderStatus");

            migrationBuilder.RenameColumn(
                name: "BaristaOrder",
                table: "Order",
                newName: "BaristaOrderStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChiefOrderStatus",
                table: "Order",
                newName: "ChiefOrder");

            migrationBuilder.RenameColumn(
                name: "BaristaOrderStatus",
                table: "Order",
                newName: "BaristaOrder");
        }
    }
}
