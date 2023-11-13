using Microsoft.EntityFrameworkCore.Migrations;
using DevicesAPI.Data;
#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevicesAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(200)", nullable: false),
                    adress = table.Column<string>(type: "varchar(200)", nullable: true),
                    kWh_energy_consumption = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "id", "adress", "description", "kWh_energy_consumption" },
                values: new object[,]
                {
                    { 1, "Entryway", "Motion Sensor", 0.75 },
                    { 2, "Bedroom", "Smart Light Bulb", 5.1999998092651367 },
                    { 3, "Front Door", "Security Camera", 2.5 },
                    { 4, "Kitchen", "Smart Refrigerator", 2.5 },
                    { 5, "Backyard", "Weather Sensor", 2.5 },
                    { 6, "Front Door", "Smart Lock", 2.5 },
                    { 7, "Living Room", "Air Quality Monitor", 2.5 },
                    { 8, "Bathroom", "Water Leak Detector", 2.5 },
                    { 9, "Entertainment Room", "Smart TV", 2.5 },
                    { 10, "Wearable", "Fitness Tracker", 2.5 },
                    { 11, "Kitchen", "Smart Oven", 2.5 },
                    { 12, "Bathroom", "Smart Mirror", 2.5 },
                    { 13, "Bathroom", "Smart Scale", 2.5 },
                    { 14, "Garden", "Automated Plant Watering System", 2.5 },
                    { 15, "Front Door", "Smart Doorbell", 0.75 },
                    { 16, "Garage", "Garage Door Opener", 5.1999998092651367 },
                    { 17, "Pet Collar", "Pet Tracker", 2.5 },
                    { 18, "Bedroom", "Smart Ceiling Fan", 2.5 },
                    { 19, "Kitchen", "Smart Faucet", 2.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
