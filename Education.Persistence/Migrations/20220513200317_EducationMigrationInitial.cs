using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreationDate", "Description", "Name", "Price", "PublishDate" },
                values: new object[] { new Guid("0005ea22-3146-45be-84b7-2177190e4b0e"), new DateTime(2022, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9542), "Java Course", "Advanced Java Course", 100m, new DateTime(2024, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9543) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreationDate", "Description", "Name", "Price", "PublishDate" },
                values: new object[] { new Guid("a0b2cc9d-a268-452f-b64b-11a6995470ec"), new DateTime(2022, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9554), "Master in Unit Test with CQRS", "Unit Tests in .NET 6", 150m, new DateTime(2024, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9554) });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreationDate", "Description", "Name", "Price", "PublishDate" },
                values: new object[] { new Guid("c4561195-0ccd-4bfd-82db-bdb89630a783"), new DateTime(2022, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9503), "Basic C# Course", "C# course from zero to hero", 80m, new DateTime(2024, 5, 13, 14, 3, 17, 392, DateTimeKind.Local).AddTicks(9510) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
