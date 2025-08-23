using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "JohnDoeEmail123@gmail.com", "John", "John123", "Doe" },
                    { 2, "AliceSmith456@gmail.com", "Alice", "Alice456", "Smith" },
                    { 3, "RobertJ789@gmail.com", "Robert", "Robert789", "Johnson" },
                    { 4, "EmilyBrown101@gmail.com", "Emily", "Emily101", "Brown" },
                    { 5, "MichaelDavis202@gmail.com", "Michael", "Michael202", "Davis" },
                    { 6, "SophiaWilson303@gmail.com", "Sophia", "Sophia303", "Wilson" },
                    { 7, "DavidMiller404@gmail.com", "David", "David404", "Miller" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Description", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 23, 44, 35, 279, DateTimeKind.Local).AddTicks(4507), "Buy strawberry ice cream", 1, "Buy ice cream", 1 },
                    { 2, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5175), "Complete the quarterly report", 3, "Finish report", 1 },
                    { 3, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5191), "Discuss project details", 2, "Call Mike", 1 },
                    { 4, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5194), "Buy vegetables and fruits", 2, "Grocery shopping", 1 },
                    { 5, new DateTime(2025, 8, 28, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5196), "Organize office desk", 1, "Clean desk", 1 },
                    { 6, new DateTime(2025, 8, 28, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5201), "Organize Alice's birthday party", 2, "Plan birthday party", 2 },
                    { 7, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5203), "Milk, eggs, and bread", 1, "Buy groceries", 2 },
                    { 8, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5205), "Attend yoga class", 2, "Gym session", 2 },
                    { 9, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5206), "Schedule dental checkup", 3, "Call dentist", 2 },
                    { 10, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5209), "Read 20 pages of a novel", 1, "Read book", 2 },
                    { 11, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5211), "Repair the front tire", 3, "Fix bike", 3 },
                    { 12, new DateTime(2025, 8, 30, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5212), "Finish reading 'C# in Depth'", 1, "Read book", 3 },
                    { 13, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5214), "Weekly project meeting", 2, "Team meeting", 3 },
                    { 14, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5226), "Add recent projects", 3, "Update resume", 3 },
                    { 15, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5228), "Wash clothes", 1, "Laundry", 3 },
                    { 16, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5230), "Roses for mom", 1, "Buy flowers", 4 },
                    { 17, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5231), "History assignment", 3, "Submit assignment", 4 },
                    { 18, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5234), "Deep clean the kitchen", 2, "Clean kitchen", 4 },
                    { 19, new DateTime(2025, 8, 28, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5236), "Photography workshop", 2, "Attend workshop", 4 },
                    { 20, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5238), "Morning meditation session", 1, "Meditation", 4 },
                    { 21, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5239), "Electricity and internet", 3, "Pay bills", 5 },
                    { 22, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5241), "Gift for friend's wedding", 2, "Buy gift", 5 },
                    { 23, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5271), "Learn about Blazor Server", 1, "Watch tutorial", 5 },
                    { 24, new DateTime(2025, 9, 2, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5273), "Decide destination and dates", 2, "Plan vacation", 5 },
                    { 25, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5275), "Clean interior and exterior", 1, "Car wash", 5 },
                    { 26, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5276), "Annual checkup", 3, "Doctor appointment", 6 },
                    { 27, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5278), "Chocolate cake for party", 2, "Bake cake", 6 },
                    { 28, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5280), "Evening walk in park", 1, "Walk the dog", 6 },
                    { 29, new DateTime(2025, 8, 28, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5282), "Organize tools and boxes", 2, "Clean garage", 6 },
                    { 30, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5283), "Cybersecurity topic", 3, "Read research paper", 6 },
                    { 31, new DateTime(2025, 8, 28, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5285), "Oil change and tire rotation", 3, "Car service", 7 },
                    { 32, new DateTime(2025, 8, 24, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5287), "Math exercises", 2, "Finish homework", 7 },
                    { 33, new DateTime(2025, 8, 25, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5289), "Weekly check-in call", 1, "Call parents", 7 },
                    { 34, new DateTime(2025, 8, 26, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5291), "Prepare weekly meal plan", 2, "Grocery shopping", 7 },
                    { 35, new DateTime(2025, 8, 27, 23, 44, 35, 280, DateTimeKind.Local).AddTicks(5293), "Sort and arrange bookshelf", 1, "Organize books", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
