using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplicationTireFitting.Models
{
    public partial class DB_Kursova_Tire_FittingContext : DbContext
    {
        public DB_Kursova_Tire_FittingContext()
        {
        }

        public DB_Kursova_Tire_FittingContext(DbContextOptions<DB_Kursova_Tire_FittingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialsOrder> MaterialsOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderWorker> OrderWorkers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrders { get; set; }
        public virtual DbSet<TypeOfCar> TypeOfCars { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-HTKQ6AM\\SQLEXPRESS;Database=DB_Kursova_Tire_Fitting;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.IdCar);

                entity.ToTable("Car");

                entity.Property(e => e.IdCar).HasColumnName("ID Car");

                entity.Property(e => e.IdClient).HasColumnName("ID Client");

                entity.Property(e => e.IdTypeOfCar).HasColumnName("ID Type of Car");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PathCarImg)
                    .HasMaxLength(150)
                    .HasColumnName("Path Car Img");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdClient)
                    .HasConstraintName("FK_Car_Client");

                entity.HasOne(d => d.IdTypeOfCarNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.IdTypeOfCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Car_Type of Car");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.ToTable("Client");

                entity.Property(e => e.IdClient).HasColumnName("ID Client");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Full Name");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Phone Number");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterials);

                entity.Property(e => e.IdMaterials).HasColumnName("ID Materials");

                entity.Property(e => e.NameMaterial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Name Material");

                entity.Property(e => e.PathMaterialsImg)
                    .HasMaxLength(150)
                    .HasColumnName("Path Materials Img");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");
            });

            modelBuilder.Entity<MaterialsOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdMaterials });

                entity.ToTable("Materials Order");

                entity.Property(e => e.IdOrder).HasColumnName("ID Order");

                entity.Property(e => e.IdMaterials).HasColumnName("ID Materials");

                entity.HasOne(d => d.IdMaterialsNavigation)
                    .WithMany(p => p.MaterialsOrders)
                    .HasForeignKey(d => d.IdMaterials)
                    .HasConstraintName("FK_Materials Order_Materials");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.MaterialsOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Materials Order_Order");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.ToTable("Order");

                entity.Property(e => e.IdOrder).HasColumnName("ID Order");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.IdCar).HasColumnName("ID Car");

                entity.Property(e => e.IdClient).HasColumnName("ID Client");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Car");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Client");
            });

            modelBuilder.Entity<OrderWorker>(entity =>
            {
                entity.HasKey(e => new { e.IdOrder, e.IdWorker });

                entity.ToTable("Order Worker");

                entity.Property(e => e.IdOrder).HasColumnName("ID Order");

                entity.Property(e => e.IdWorker).HasColumnName("ID Worker");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.OrderWorkers)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Order Worker_Order");

                entity.HasOne(d => d.IdWorkerNavigation)
                    .WithMany(p => p.OrderWorkers)
                    .HasForeignKey(d => d.IdWorker)
                    .HasConstraintName("FK_Order Worker_Worker");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.IdPosition);

                entity.ToTable("Position");

                entity.Property(e => e.IdPosition).HasColumnName("ID Position");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.ToTable("Service");

                entity.Property(e => e.IdService).HasColumnName("ID Service");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 5)");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Service Name");
            });

            modelBuilder.Entity<ServiceOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdService, e.IdOrder });

                entity.ToTable("Service Order");

                entity.Property(e => e.IdService).HasColumnName("ID Service");

                entity.Property(e => e.IdOrder).HasColumnName("ID Order");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("FK_Service Order_Order");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServiceOrders)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("FK_Service Order_Service");
            });

            modelBuilder.Entity<TypeOfCar>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfCar);

                entity.ToTable("Type of Car");

                entity.Property(e => e.IdTypeOfCar).HasColumnName("ID Type of Car");

                entity.Property(e => e.TypeOfCar1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Type of Car");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.IdWorker);

                entity.ToTable("Worker");

                entity.Property(e => e.IdWorker).HasColumnName("ID Worker");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date of Birth");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Full Name");

                entity.Property(e => e.IdPosition).HasColumnName("ID Position");

                entity.Property(e => e.PathWorkerImg)
                    .HasMaxLength(150)
                    .HasColumnName("Path Worker Img");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("Phone Number");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Worker_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
