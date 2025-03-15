using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAboutMeVariableToTutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 1,
                column: "AboutMe",
                value: "Programista z 10-letnim doświadczeniem w Javie");

            migrationBuilder.UpdateData(
                table: "Tutors",
                keyColumn: "Id",
                keyValue: 2,
                column: "AboutMe",
                value: " Ekspertka w tworzeniu aplikacji backendowych.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Tutors");
        }
    }
}
