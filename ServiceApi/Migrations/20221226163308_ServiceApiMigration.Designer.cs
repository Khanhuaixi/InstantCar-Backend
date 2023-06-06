﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceApi.Models;

namespace ServiceApi.Migrations
{
    [DbContext(typeof(BackendDBContext))]
    [Migration("20221226163308_ServiceApiMigration")]
    partial class ServiceApiMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceApi.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingEndDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("booking_end_date");

                    b.Property<string>("BookingId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("booking_id");

                    b.Property<string>("BookingPaymentMethod")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("booking_payment_method");

                    b.Property<string>("BookingStartDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("booking_start_date");

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_id");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("ServiceApi.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarAddress")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_address");

                    b.Property<string>("CarId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_id");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_model_id");

                    b.Property<double>("CarRentalRate")
                        .HasColumnType("float")
                        .HasColumnName("car_rental_rate");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("ServiceApi.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrandName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_brand_name");

                    b.Property<string>("CarImageLink")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_image_link");

                    b.Property<string>("CarModelId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_model_id");

                    b.Property<string>("CarModelName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_model_name");

                    b.Property<string>("CarPetrolType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_petrol_type");

                    b.Property<string>("CarTransmissionType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_transmission_type");

                    b.Property<string>("CarVehicleType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("car_vehicle_type");

                    b.HasKey("Id");

                    b.ToTable("CarModel");
                });
#pragma warning restore 612, 618
        }
    }
}
