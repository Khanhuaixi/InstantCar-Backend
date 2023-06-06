using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ServiceApi.Models
{
    public partial class BackendDBContext : DbContext
    {
        public BackendDBContext()
        {
        }

        public BackendDBContext(DbContextOptions<BackendDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=AutopiaDB;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseSqlServer("Server=tcp:testdb.database.windows.net,1433;Initial Catalog=AMCDB;Persist Security Info=False;User ID=admin;Password=Admin123987;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                optionsBuilder.UseSqlServer("Server=tcp:mydbinstance.ccm25hbb5dlf.us-east-1.rds.amazonaws.com,1433; Database = InstantCarDB; User ID=admin; Password=admin-password; Trusted_Connection = False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.ToTable("CarModel");

                entity.Property(e => e.CarModelId).HasColumnName("car_model_id");

                entity.Property(e => e.CarBrandName).HasColumnName("car_brand_name");

                entity.Property(e => e.CarModelName).HasColumnName("car_model_name");

                entity.Property(e => e.CarVehicleType).HasColumnName("car_vehicle_type");

                entity.Property(e => e.CarPetrolType).HasColumnName("car_petrol_type");

                entity.Property(e => e.CarTransmissionType).HasColumnName("car_transmission_type");

                entity.Property(e => e.CarImageLink).HasColumnName("car_image_link");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarModelId).HasColumnName("car_model_id");

                entity.Property(e => e.CarRentalRate).HasColumnName("car_rental_rate");

                entity.Property(e => e.CarAddress).HasColumnName("car_address");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BookingStartDate).HasColumnName("booking_start_date");

                entity.Property(e => e.BookingEndDate).HasColumnName("booking_end_date");

                entity.Property(e => e.BookingPaymentMethod).HasColumnName("booking_payment_method");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });


            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}