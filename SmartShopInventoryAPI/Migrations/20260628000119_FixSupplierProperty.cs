using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartShopInventoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixSupplierProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasDelayedDelivers",
                table: "Suppliers",
                newName: "HasDelayedDeliveries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasDelayedDeliveries",
                table: "Suppliers",
                newName: "HasDelayedDelivers");
        }
    }
}
