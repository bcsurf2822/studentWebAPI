using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace firstAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "DOB", "Email", "StudentName" },
                values: new object[,]
                {
                    { 1, "NJ", new DateTime(1990, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "benjamin@email.com", "Benjamin" },
                    { 2, "CA", new DateTime(1995, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "sophia@email.com", "Sophia" },
                    { 3, "NY", new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "liam@email.com", "Liam" },
                    { 4, "TX", new DateTime(1994, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "olivia@email.com", "Olivia" },
                    { 5, "FL", new DateTime(1993, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "noah@email.com", "Noah" },
                    { 6, "WA", new DateTime(1991, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma@email.com", "Emma" },
                    { 7, "NV", new DateTime(1989, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "james@email.com", "James" },
                    { 8, "IL", new DateTime(1996, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ava@email.com", "Ava" },
                    { 9, "OH", new DateTime(1993, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "william@email.com", "William" },
                    { 10, "PA", new DateTime(1992, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "mia@email.com", "Mia" },
                    { 11, "GA", new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucas@email.com", "Lucas" },
                    { 12, "MI", new DateTime(1991, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "charlotte@email.com", "Charlotte" },
                    { 13, "NC", new DateTime(1990, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "henry@email.com", "Henry" },
                    { 14, "VA", new DateTime(1995, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "amelia@email.com", "Amelia" },
                    { 15, "MA", new DateTime(1993, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "alexander@email.com", "Alexander" },
                    { 16, "CO", new DateTime(1996, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "evelyn@email.com", "Evelyn" },
                    { 17, "AZ", new DateTime(1988, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "michael@email.com", "Michael" },
                    { 18, "OR", new DateTime(1994, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "harper@email.com", "Harper" },
                    { 19, "WI", new DateTime(1992, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "daniel@email.com", "Daniel" },
                    { 20, "MN", new DateTime(1990, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ella@email.com", "Ella" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
