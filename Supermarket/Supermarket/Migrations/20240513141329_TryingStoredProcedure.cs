using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class TryingStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[CreateUser]
                    @Name nvarchar(MAX),
                    @Password nvarchar(MAX),
                    @UserType nvarchar(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Insert into Users([Name], [Password], [UserType])
                    Values(@Name, @Password, @UserType)
                END";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
