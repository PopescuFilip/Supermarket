using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[AuthenticateUser]
                    @Name nvarchar(MAX),
                    @Password nvarchar(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Users where Name = @Name and Password = @Password
                END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
