using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Models
{
    public partial class CarBuyContext : DbContext
    {
        public CarBuyContext()
        {
        }

        public CarBuyContext(DbContextOptions<CarBuyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BodyType> BodyType { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Condition> Condition { get; set; }
        public virtual DbSet<Cylinders> Cylinders { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<EngineDescription> EngineDescription { get; set; }
        public virtual DbSet<EngineSize> EngineSize { get; set; }
        public virtual DbSet<FuelEconomy> FuelEconomy { get; set; }
        public virtual DbSet<FuelType> FuelType { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Make> Make { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<ModelColour> ModelColour { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<SellerType> SellerType { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<Transmission> Transmission { get; set; }
        public virtual DbSet<Variant> Variant { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategory { get; set; }
        public virtual DbSet<VehicleImage> VehicleImage { get; set; }
        public virtual DbSet<VehicleType> VehicleType { get; set; }
        public virtual DbSet<WhistList> WhistList { get; set; }
        public virtual DbSet<Year> Year { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3TL00NE\\SQLEXPRESS;Database=CarBuy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("Comment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(50);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.Property(e => e.Condition1)
                    .HasColumnName("Condition")
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cylinders>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VehicaleId)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EngineDescription>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EngineSize>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuelEconomy>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasIndex(e => e.ModelId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Images_ModelId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LogoImage).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasIndex(e => e.MakeId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Make_Id");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Year_Id");
            });

            modelBuilder.Entity<ModelColour>(entity =>
            {
                entity.HasIndex(e => e.ColourId);

                entity.HasIndex(e => e.ModelId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.ModelColour)
                    .HasForeignKey(d => d.ColourId)
                    .HasConstraintName("FK_ModelColour_Colour");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelColour)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_ModelId");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SellerType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SellerType1)
                    .HasColumnName("SellerType")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.HasIndex(e => e.ModelId);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Varient).HasMaxLength(250);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Variant)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Variant_Model");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(e => e.BodyTypeId);

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.ColourId);

                entity.HasIndex(e => e.ConditionId);

                entity.HasIndex(e => e.CylindersId);

                entity.HasIndex(e => e.EngineDescriptionId);

                entity.HasIndex(e => e.EngineSizeId);

                entity.HasIndex(e => e.FuelEconomyId);

                entity.HasIndex(e => e.FuelTypeId);

                entity.HasIndex(e => e.LocationId);

                entity.HasIndex(e => e.MakeId);

                entity.HasIndex(e => e.ModelId);

                entity.HasIndex(e => e.SellerTypeId);

                entity.HasIndex(e => e.TransmissionId);

                entity.HasIndex(e => e.Variant);

                entity.HasIndex(e => e.VehicalTypeId);

                entity.HasIndex(e => e.VehicleCategoryId);

                entity.HasIndex(e => e.VehicleImageId);

                entity.HasIndex(e => e.YearId);

                entity.Property(e => e.AirConditioning)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AuctionGrade)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DriveTrain)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsRegistered)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Odometers)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.RegistrationPlate).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Vin)
                    .HasColumnName("VIN")
                    .HasMaxLength(250);

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Body_Type");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category_Id");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ColourId)
                    .HasConstraintName("FK_Vehicle_Colour");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_Vehicle_Condition");

                entity.HasOne(d => d.Cylinders)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.CylindersId)
                    .HasConstraintName("FK_Cylinders");

                entity.HasOne(d => d.EngineDescription)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.EngineDescriptionId)
                    .HasConstraintName("FK_Engin_Description");

                entity.HasOne(d => d.EngineSize)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.EngineSizeId)
                    .HasConstraintName("FK_Engine_Size");

                entity.HasOne(d => d.FuelEconomy)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FuelEconomyId)
                    .HasConstraintName("FK_Fuel_Economy");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.FuelTypeId)
                    .HasConstraintName("FK_Fuel_Type");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Location");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK_Vehicle_Make");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Vehicle_ModelId");

                entity.HasOne(d => d.SellerType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.SellerTypeId)
                    .HasConstraintName("FK_Vehicle_SellerType");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.TransmissionId)
                    .HasConstraintName("FK_Transmission");

                entity.HasOne(d => d.VariantNavigation)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Variant)
                    .HasConstraintName("FK_Vehicle_Variant");

                entity.HasOne(d => d.VehicalType)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicalTypeId)
                    .HasConstraintName("FK_Vehicle_Type");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .HasConstraintName("FK_Vehicle_VehicleCategory");

                entity.HasOne(d => d.VehicleImage)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.VehicleImageId)
                    .HasConstraintName("FK_Vehicle_VehicleImage");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_Vehicle_Year");
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.Property(e => e.VehicleCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleImage>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WhistList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WhistList)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_WhistList_AspNetUsers");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.WhistList)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_WhistList_Vehicle");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
