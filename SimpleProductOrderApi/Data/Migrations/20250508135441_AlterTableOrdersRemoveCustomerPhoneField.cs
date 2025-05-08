using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleProductOrderApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableOrdersRemoveCustomerPhoneField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
