using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class newProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[GetAllByName]
                    @Name nvarchar(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Users where Name = @Name
                END";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
