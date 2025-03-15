using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "Id", "FirstName", "LastName", "Specialisation" },
                values: new object[,]
                {
                    { 1, "Jan", "Kowalski", "Java" },
                    { 2, "Anna", "Nowak", "Networking" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "EndDate", "NumberOfStudents", "Price", "StartDate", "Title", "TutorId" },
                values: new object[,]
                {
                    { 1, "Podstawy programowania z Javy", new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 499.99m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podwstawy z Javy", 1 },
                    { 2, "Podstawowe zagadnienia zwiazane z sieciami", new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 749.99m, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Podstawy sieci", 2 }
                });

            migrationBuilder.InsertData(
                table: "PersonCourses",
                columns: new[] { "CourseId", "PersonId", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonCourses",
                keyColumns: new[] { "CourseId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonCourses",
                keyColumns: new[] { "CourseId", "PersonId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonCourses",
                keyColumns: new[] { "CourseId", "PersonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
