﻿using Microsoft.EntityFrameworkCore.Migrations;
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
        }
        public static void CreateUser(MigrationBuilder migrationBuilder)
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
        public static void Authenticate(MigrationBuilder migrationBuilder)
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
    }
}
