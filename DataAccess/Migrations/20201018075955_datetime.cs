using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Users",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
