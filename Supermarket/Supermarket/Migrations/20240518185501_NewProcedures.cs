using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class NewProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[CreateCategory]
                    @Name nvarchar(MAX),
                    @IsActive bit
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Insert into Categories([Name], [IsActive])
                    Values(@Name, @IsActive)
                END";
            migrationBuilder.Sql(procedure);

            var procedure1 = @"CREATE PROCEDURE [dbo].[CreateSupplier]
                    @Name nvarchar(MAX),
                    @CountryOfOrigin nvarchar(MAX),
                    @IsActive bit
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Insert into Suppliers([Name], [CountryOfOrigin], [IsActive])
                    Values(@Name, @CountryOfOrigin, @IsActive)
                END";
            migrationBuilder.Sql(procedure1);

            var procedure2 = @"CREATE PROCEDURE [dbo].[GetAllCategories]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Categories where IsActive = 1 
                END";

            migrationBuilder.Sql(procedure2);

            var procedure3 = @"CREATE PROCEDURE [dbo].[GetAllSuppliers]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Suppliers where IsActive = 1 
                END";

            migrationBuilder.Sql(procedure3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
