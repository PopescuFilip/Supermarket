using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.DB
{
    public static class StoredProcedures
    {
        public static void AddAllProcedures(MigrationBuilder migrationBuilder) 
        {
            CreateUser(migrationBuilder);
            Authenticate(migrationBuilder);
            RegisterValidation(migrationBuilder);
            CreateCategory(migrationBuilder);
            CreateSupplier(migrationBuilder);
            GetAllCategories(migrationBuilder);
            GetAllSuppliers(migrationBuilder);
        }
        private static void CreateUser(MigrationBuilder migrationBuilder)
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
        }
        private static void Authenticate(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[AuthenticateUser]
                    @Name nvarchar(MAX),
                    @Password nvarchar(MAX)
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Users where IsActive = 1 and Name = @Name and Password = @Password 
                END";

            migrationBuilder.Sql(procedure);
        }
        private static void RegisterValidation(MigrationBuilder migrationBuilder) 
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
        private static void CreateCategory(MigrationBuilder migrationBuilder)
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
        }
        private static void CreateSupplier(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[CreateSupplier]
                    @Name nvarchar(MAX),
                    @CountryOfOrigin nvarchar(MAX),
                    @IsActive bit
                AS
                BEGIN
                    SET NOCOUNT ON;
                    Insert into Suppliers([Name], [CountryOfOrigin], [IsActive])
                    Values(@Name, @CountryOfOrigin, @IsActive)
                END";
            migrationBuilder.Sql(procedure);
        }
        private static void GetAllCategories(MigrationBuilder migrationBuilder) 
        {
            var procedure = @"CREATE PROCEDURE [dbo].[GetAllCategories]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Categories where IsActive = 1 
                END";

            migrationBuilder.Sql(procedure);
        }
        private static void GetAllSuppliers(MigrationBuilder migrationBuilder)
        {
            var procedure = @"CREATE PROCEDURE [dbo].[GetAllSuppliers]
                AS
                BEGIN
                    SET NOCOUNT ON;
                    select * from Suppliers where IsActive = 1 
                END";

            migrationBuilder.Sql(procedure);
        }
    }
}
