using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class DelUpProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[UpdateCategory]
                    @Name nvarchar(MAX),
                    @Id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Update Categories set Name = @Name where @Id = Id
                END";
            migrationBuilder.Sql(procedure);

            var procedure1 = @"CREATE PROCEDURE [dbo].[UpdateSupplier]
                    @Name nvarchar(MAX),
                    @CountryOfOrigin nvarchar(MAX),
                    @Id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Update Suppliers set Name = @Name, CountryOfOrigin = @CountryOfOrigin
                    where Id = @Id
                END";
            migrationBuilder.Sql(procedure1);

            var procedure2 = @"CREATE PROCEDURE [dbo].[DeleteCategory]
                    @Id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Update Categories set IsActive = 0 where @Id = Id
                END";
            migrationBuilder.Sql(procedure2);

            var procedure3 = @"CREATE PROCEDURE [dbo].[DeleteSupplier]
                    @Id int
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Update Suppliers set IsActive = 0 where Id = @Id
                END";
            migrationBuilder.Sql(procedure3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
