using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Infrustructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceTotal",
                table: "Products",
                newName: "OldPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "NewPrice",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NewPrice", "OldPrice" },
                values: new object[] { 10.99m, 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewPrice",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "OldPrice",
                table: "Products",
                newName: "PriceTotal");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriceTotal",
                value: 10.99m);
        }
    }
}
