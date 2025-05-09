using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleProductOrderApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreateOrder_SPAddResultMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                ALTER PROCEDURE sp_CreateOrder
                    @CustomerName NVARCHAR(MAX),
                    @CustomerEmail NVARCHAR(MAX),
                    @Items NVARCHAR(MAX),
                    @ResultMessage NVARCHAR(MAX) OUTPUT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    BEGIN TRY
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

                        SET @ResultMessage = 'Success';
                    END TRY
                    BEGIN CATCH
                        SET @ResultMessage = CONCAT('Failed. ', ERROR_MESSAGE());
                    END CATCH
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
