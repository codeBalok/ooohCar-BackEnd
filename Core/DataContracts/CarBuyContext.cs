using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CarsbyEF.DataContracts
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

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<CarEquipment> CarEquipments { get; set; }
        public virtual DbSet<CarGeneration> CarGenerations { get; set; }
        public virtual DbSet<CarMake> CarMakes { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarOption> CarOptions { get; set; }
        public virtual DbSet<CarOptionValue> CarOptionValues { get; set; }
        public virtual DbSet<CarSerie> CarSeries { get; set; }
        public virtual DbSet<CarSpecification> CarSpecifications { get; set; }
        public virtual DbSet<CarSpecificationValue> CarSpecificationValues { get; set; }
        public virtual DbSet<CarTrim> CarTrims { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<Cylinder> Cylinders { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<EngineDescription> EngineDescriptions { get; set; }
        public virtual DbSet<EngineSize> EngineSizes { get; set; }
        public virtual DbSet<FuelEconomy> FuelEconomies { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<MakeImage> MakeImages { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<ModelColour> ModelColours { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<SellerType> SellerTypes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Transmission> Transmissions { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategories { get; set; }
        public virtual DbSet<VehicleImage> VehicleImages { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<WhistList> WhistLists { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=CarBuy;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.ToTable("BodyType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CarEquipment>(entity =>
            {
                entity.HasKey(e => e.IdCarEquipment)
                    .HasName("pk_car_equipment");

                entity.ToTable("car_equipment");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarEquipment)
                    .HasColumnName("id_car_equipment")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarTrim)
                    .HasColumnName("id_car_trim")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial109)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL109")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarEquipments)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_equipment_car_type");
            });

            modelBuilder.Entity<CarGeneration>(entity =>
            {
                entity.HasKey(e => e.IdCarGeneration)
                    .HasName("pk_car_generation");

                entity.ToTable("car_generation");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarGeneration)
                    .HasColumnName("id_car_generation")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarModel)
                    .HasColumnName("id_car_model")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial112)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL112")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.Property(e => e.YearBegin)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("year_begin")
                    .HasComment("TRIAL");

                entity.Property(e => e.YearEnd)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("year_end")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarModelNavigation)
                    .WithMany(p => p.CarGenerations)
                    .HasForeignKey(d => d.IdCarModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_generation_car_model");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarGenerations)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_generation_car_type");
            });

            modelBuilder.Entity<CarMake>(entity =>
            {
                entity.HasKey(e => e.IdCarMake)
                    .HasName("pk_car_make");

                entity.ToTable("car_make");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarMake)
                    .HasColumnName("id_car_make")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial112)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL112")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarMakes)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_make_car_type");
            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.IdCarModel)
                    .HasName("pk_car_model");

                entity.ToTable("car_model");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarModel)
                    .HasColumnName("id_car_model")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarMake)
                    .HasColumnName("id_car_make")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial116)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL116")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarMakeNavigation)
                    .WithMany(p => p.CarModels)
                    .HasForeignKey(d => d.IdCarMake)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_model_car_make");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarModels)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_model_car_type");
            });

            modelBuilder.Entity<CarOption>(entity =>
            {
                entity.HasKey(e => e.IdCarOption)
                    .HasName("pk_car_option");

                entity.ToTable("car_option");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarOption)
                    .HasColumnName("id_car_option")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdParent)
                    .HasColumnName("id_parent")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial119)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL119")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarOptions)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_option_car_type");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("fk_car_option_car_option");
            });

            modelBuilder.Entity<CarOptionValue>(entity =>
            {
                entity.HasKey(e => e.IdCarOptionValue)
                    .HasName("pk_car_option_value");

                entity.ToTable("car_option_value");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarOptionValue)
                    .HasColumnName("id_car_option_value")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarEquipment)
                    .HasColumnName("id_car_equipment")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarOption)
                    .HasColumnName("id_car_option")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.IsBase)
                    .HasColumnName("is_base")
                    .HasDefaultValueSql("((1))")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial122)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL122")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarEquipmentNavigation)
                    .WithMany(p => p.CarOptionValues)
                    .HasForeignKey(d => d.IdCarEquipment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_option_value_car_equipment");

                entity.HasOne(d => d.IdCarOptionNavigation)
                    .WithMany(p => p.CarOptionValues)
                    .HasForeignKey(d => d.IdCarOption)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_option_value_car_option");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarOptionValues)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_option_value_car_type");
            });

            modelBuilder.Entity<CarSerie>(entity =>
            {
                entity.HasKey(e => e.IdCarSerie)
                    .HasName("pk_car_serie");

                entity.ToTable("car_serie");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarSerie)
                    .HasColumnName("id_car_serie")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarGeneration)
                    .HasColumnName("id_car_generation")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarModel)
                    .HasColumnName("id_car_model")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial129)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL129")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarGenerationNavigation)
                    .WithMany(p => p.CarSeries)
                    .HasForeignKey(d => d.IdCarGeneration)
                    .HasConstraintName("fk_car_serie_car_generation");

                entity.HasOne(d => d.IdCarModelNavigation)
                    .WithMany(p => p.CarSeries)
                    .HasForeignKey(d => d.IdCarModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_serie_car_model");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarSeries)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_serie_car_type");
            });

            modelBuilder.Entity<CarSpecification>(entity =>
            {
                entity.HasKey(e => e.IdCarSpecification)
                    .HasName("pk_car_specification");

                entity.ToTable("car_specification");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarSpecification)
                    .HasColumnName("id_car_specification")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdParent)
                    .HasColumnName("id_parent")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial132)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL132")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarSpecifications)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_specification_car_type");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("fk_car_specification_car_specification");
            });

            modelBuilder.Entity<CarSpecificationValue>(entity =>
            {
                entity.HasKey(e => e.IdCarSpecificationValue)
                    .HasName("pk_car_specification_value");

                entity.ToTable("car_specification_value");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarSpecificationValue)
                    .HasColumnName("id_car_specification_value")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarSpecification)
                    .HasColumnName("id_car_specification")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarTrim)
                    .HasColumnName("id_car_trim")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial132)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL132")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unit")
                    .HasComment("TRIAL");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("value")
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarSpecificationNavigation)
                    .WithMany(p => p.CarSpecificationValues)
                    .HasForeignKey(d => d.IdCarSpecification)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_specification_value_car_specification");

                entity.HasOne(d => d.IdCarTrimNavigation)
                    .WithMany(p => p.CarSpecificationValues)
                    .HasForeignKey(d => d.IdCarTrim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_specification_value_car_trim");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarSpecificationValues)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_specification_value_car_type");
            });

            modelBuilder.Entity<CarTrim>(entity =>
            {
                entity.HasKey(e => e.IdCarTrim)
                    .HasName("pk_car_trim");

                entity.ToTable("car_trim");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarTrim)
                    .HasColumnName("id_car_trim")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasComment("TRIAL");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasComment("TRIAL");

                entity.Property(e => e.EndProductionYear)
                    .HasColumnName("end_production_year")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarModel)
                    .HasColumnName("id_car_model")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarSerie)
                    .HasColumnName("id_car_serie")
                    .HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.StartProductionYear)
                    .HasColumnName("start_production_year")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial148)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL148")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");

                entity.HasOne(d => d.IdCarModelNavigation)
                    .WithMany(p => p.CarTrims)
                    .HasForeignKey(d => d.IdCarModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_trim_car_model");

                entity.HasOne(d => d.IdCarSerieNavigation)
                    .WithMany(p => p.CarTrims)
                    .HasForeignKey(d => d.IdCarSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_trim_car_serie");

                entity.HasOne(d => d.IdCarTypeNavigation)
                    .WithMany(p => p.CarTrims)
                    .HasForeignKey(d => d.IdCarType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_car_trim_car_type");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.HasKey(e => e.IdCarType)
                    .HasName("pk_car_type");

                entity.ToTable("car_type");

                entity.HasComment("TRIAL");

                entity.Property(e => e.IdCarType)
                    .HasColumnName("id_car_type")
                    .HasComment("TRIAL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("TRIAL");

                entity.Property(e => e.Trial152)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TRIAL152")
                    .IsFixedLength(true)
                    .HasComment("TRIAL");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("Colour");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.Comment1)
                    .IsRequired()
                    .HasColumnName("Comment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserType).HasMaxLength(50);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("Condition");

                entity.Property(e => e.Condition1)
                    .HasMaxLength(250)
                    .HasColumnName("Condition");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cylinder>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VehicaleId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<EngineDescription>(entity =>
            {
                entity.ToTable("EngineDescription");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EngineSize>(entity =>
            {
                entity.ToTable("EngineSize");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuelEconomy>(entity =>
            {
                entity.ToTable("FuelEconomy");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.ToTable("FuelType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.ModelId, "IX_Images_ModelId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Images_ModelId");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Make>(entity =>
            {
                entity.ToTable("Make");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LogoImage).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MakeImage>(entity =>
            {
                entity.ToTable("Make_Image");

                entity.Property(e => e.ImageName).HasMaxLength(200);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.HasIndex(e => e.MakeId, "IX_Model_MakeId");

                entity.HasIndex(e => e.YearId, "IX_Model_YearId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.MakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Make_Id");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Year_Id");
            });

            modelBuilder.Entity<ModelColour>(entity =>
            {
                entity.ToTable("ModelColour");

                entity.HasIndex(e => e.ColourId, "IX_ModelColour_ColourId");

                entity.HasIndex(e => e.ModelId, "IX_ModelColour_ModelId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.ModelColours)
                    .HasForeignKey(d => d.ColourId)
                    .HasConstraintName("FK_ModelColour_Colour");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.ModelColours)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_ModelId");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Region_Location");
            });

            modelBuilder.Entity<SellerType>(entity =>
            {
                entity.ToTable("SellerType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SellerType1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SellerType");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                entity.ToTable("Transmission");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.ToTable("Variant");

                entity.HasIndex(e => e.ModelId, "IX_Variant_ModelId");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Varient).HasMaxLength(250);

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Variant_Model");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.BodyTypeId, "IX_Vehicle_BodyTypeId");

                entity.HasIndex(e => e.CategoryId, "IX_Vehicle_CategoryId");

                entity.HasIndex(e => e.ColourId, "IX_Vehicle_ColourId");

                entity.HasIndex(e => e.ConditionId, "IX_Vehicle_ConditionId");

                entity.HasIndex(e => e.CylindersId, "IX_Vehicle_CylindersId");

                entity.HasIndex(e => e.EngineDescriptionId, "IX_Vehicle_EngineDescriptionId");

                entity.HasIndex(e => e.EngineSizeId, "IX_Vehicle_EngineSizeId");

                entity.HasIndex(e => e.FuelEconomyId, "IX_Vehicle_FuelEconomyId");

                entity.HasIndex(e => e.FuelTypeId, "IX_Vehicle_FuelTypeId");

                entity.HasIndex(e => e.LocationId, "IX_Vehicle_LocationId");

                entity.HasIndex(e => e.MakeId, "IX_Vehicle_MakeId");

                entity.HasIndex(e => e.ModelId, "IX_Vehicle_ModelId");

                entity.HasIndex(e => e.SellerTypeId, "IX_Vehicle_SellerTypeId");

                entity.HasIndex(e => e.TransmissionId, "IX_Vehicle_TransmissionId");

                entity.HasIndex(e => e.Variant, "IX_Vehicle_Variant");

                entity.HasIndex(e => e.VehicalTypeId, "IX_Vehicle_VehicalTypeId");

                entity.HasIndex(e => e.VehicleCategoryId, "IX_Vehicle_VehicleCategoryId");

                entity.HasIndex(e => e.VehicleImageId, "IX_Vehicle_VehicleImageId");

                entity.HasIndex(e => e.YearId, "IX_Vehicle_YearId");

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

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RegistrationPlate).HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Vin)
                    .HasMaxLength(250)
                    .HasColumnName("VIN");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BodyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Body_Type");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category_Id");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ColourId)
                    .HasConstraintName("FK_Vehicle_Colour");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ConditionId)
                    .HasConstraintName("FK_Vehicle_Condition");

                entity.HasOne(d => d.Cylinders)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CylindersId)
                    .HasConstraintName("FK_Cylinders");

                entity.HasOne(d => d.EngineDescription)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.EngineDescriptionId)
                    .HasConstraintName("FK_Engin_Description");

                entity.HasOne(d => d.EngineSize)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.EngineSizeId)
                    .HasConstraintName("FK_Engine_Size");

                entity.HasOne(d => d.FuelEconomy)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelEconomyId)
                    .HasConstraintName("FK_Fuel_Economy");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.FuelTypeId)
                    .HasConstraintName("FK_Fuel_Type");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Location");

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.MakeId)
                    .HasConstraintName("FK_Vehicle_Make");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Vehicle_ModelId");

                entity.HasOne(d => d.SellerType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.SellerTypeId)
                    .HasConstraintName("FK_Vehicle_SellerType");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.TransmissionId)
                    .HasConstraintName("FK_Transmission");

                entity.HasOne(d => d.VariantNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.Variant)
                    .HasConstraintName("FK_Vehicle_Variant");

                entity.HasOne(d => d.VehicalType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicalTypeId)
                    .HasConstraintName("FK_Vehicle_Type");

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .HasConstraintName("FK_Vehicle_VehicleCategory");

                entity.HasOne(d => d.VehicleImage)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleImageId)
                    .HasConstraintName("FK_Vehicle_VehicleImage");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.YearId)
                    .HasConstraintName("FK_Vehicle_Year");
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.ToTable("VehicleCategory");

                entity.Property(e => e.VehicleCategoryId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VehicleImage>(entity =>
            {
                entity.ToTable("VehicleImage");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<WhistList>(entity =>
            {
                entity.ToTable("WhistList");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WhistLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_WhistList_AspNetUsers");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("Year");

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
