using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[CreateUser]
                    @Name nvarchar(MAX),
                    @Password nvarchar(MAX),
                    @UserType nvarchar(MAX),
                    @IsActive bit
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Insert into Users([Name], [Password], [UserType], [IsActive])
                    Values(@Name, @Password, @UserType, @IsActive)
                END";
            migrationBuilder.Sql(procedure);

            var procedure2 = @"CREATE PROCEDURE [dbo].[AuthenticateUser]
                    @Name nvarchar(MAX),
                    @Password nvarchar(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Users where IsActive = 1 and Name = @Name and Password = @Password 
                END";

            migrationBuilder.Sql(procedure2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
