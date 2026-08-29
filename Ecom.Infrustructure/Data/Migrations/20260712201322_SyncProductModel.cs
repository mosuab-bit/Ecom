using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecom.Infrustructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SyncProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Photo",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "Id", "ImageName", "ProductId" },
                values: new object[] { 3, "test", 1 });
        }
    }
}
