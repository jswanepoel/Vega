using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make3')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES ('Make4')");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make1-NodelA', (SELECT Id FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make1-NodelB', (SELECT Id FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make1-NodelC', (SELECT Id FROM Makes WHERE Name = 'Make1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make1-NodelD', (SELECT Id FROM Makes WHERE Name = 'Make1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make2-NodelA', (SELECT Id FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make2-NodelB', (SELECT Id FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make2-NodelC', (SELECT Id FROM Makes WHERE Name = 'Make2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make2-NodelD', (SELECT Id FROM Makes WHERE Name = 'Make2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make3-NodelA', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make3-NodelB', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make3-NodelC', (SELECT Id FROM Makes WHERE Name = 'Make3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make3-NodelD', (SELECT Id FROM Makes WHERE Name = 'Make3'))");

            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make4-NodelA', (SELECT Id FROM Makes WHERE Name = 'Make4'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make4-NodelB', (SELECT Id FROM Makes WHERE Name = 'Make4'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make4-NodelC', (SELECT Id FROM Makes WHERE Name = 'Make4'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakeId) VALUES ('Make4-NodelD', (SELECT Id FROM Makes WHERE Name = 'Make4'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make1', 'Make2', 'Make3', 'Make4')");
        }
    }
}