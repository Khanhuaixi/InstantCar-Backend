using Microsoft.EntityFrameworkCore.Migrations;

namespace ServiceApi.Migrations
{
    public partial class ServiceApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    booking_start_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    booking_end_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    booking_payment_method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_model_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_rental_rate = table.Column<double>(type: "float", nullable: false),
                    car_address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_model_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_brand_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_model_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_vehicle_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_petrol_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_transmission_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    car_image_link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CarModel");
        }
    }
}
