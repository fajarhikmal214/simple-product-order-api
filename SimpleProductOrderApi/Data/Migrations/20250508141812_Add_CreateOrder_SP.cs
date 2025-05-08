using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleProductOrderApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_CreateOrder_SP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE sp_CreateOrder
                    @CustomerName NVARCHAR(MAX),
                    @CustomerEmail NVARCHAR(MAX),
                    @Items NVARCHAR(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;

                    INSERT INTO Orders (CustomerName, CustomerEmail, CreatedAt)
                    VALUES (@CustomerName, @CustomerEmail, GETUTCDATE());

                    DECLARE @OrderId INT = SCOPE_IDENTITY();

                    -- Parse JSON array into table and loop through it
                    INSERT INTO OrderItems (OrderId, ProductId, ProductName, ProductPrice, Quantity)
                    SELECT 
                        @OrderId,
                        p.Id AS ProductId,
                        p.Name AS ProductName,
                        p.Price AS ProductPrice,
                        items.Quantity
                    FROM OPENJSON(@Items)
                    WITH (
                        productId INT '$.productId',
                        quantity INT '$.quantity'
                    ) AS items
                    INNER JOIN Products p ON p.Id = items.productId;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_CreateOrder");
        }
    }
}
