using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class AddIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Price",
                table: "Price");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Auction",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_DriveTrain",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Grade",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "DriveTrain");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_AuctionId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_DriveTrain",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_GradeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Price_VehicleId",
                table: "Price");

            migrationBuilder.DropColumn(
                name: "AuctionId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "DriveTrain",
                table: "Vehicle",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vehicle",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "AuctionGrade",
                table: "Vehicle",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColourId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsRegistered",
                table: "Vehicle",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SellerTypeId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleCategoryId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleImageId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "Vehicle",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellerType = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleCategory",
                columns: table => new
                {
                    VehicleCategoryId = table.Column<int>(nullable: false),
                    VehicleType = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategory", x => x.VehicleCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    ModelId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ColourId",
                table: "Vehicle",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_SellerTypeId",
                table: "Vehicle",
                column: "SellerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleCategoryId",
                table: "Vehicle",
                column: "VehicleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleImageId",
                table: "Vehicle",
                column: "VehicleImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_YearId",
                table: "Vehicle",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Colour",
                table: "Vehicle",
                column: "ColourId",
                principalTable: "Colour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_SellerType",
                table: "Vehicle",
                column: "SellerTypeId",
                principalTable: "SellerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleCategory",
                table: "Vehicle",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategory",
                principalColumn: "VehicleCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleImage",
                table: "Vehicle",
                column: "VehicleImageId",
                principalTable: "VehicleImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Year",
                table: "Vehicle",
                column: "YearId",
                principalTable: "Year",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Colour",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_SellerType",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleCategory",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleImage",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Year",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SellerType");

            migrationBuilder.DropTable(
                name: "VehicleCategory");

            migrationBuilder.DropTable(
                name: "VehicleImage");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ColourId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_SellerTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleCategoryId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleImageId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_YearId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "AuctionGrade",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ColourId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "SellerTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleCategoryId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleImageId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "DriveTrain",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Vehicle",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuctionId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Price",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Auction = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveTrain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DriveTrain = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveTrain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Grade = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_AuctionId",
                table: "Vehicle",
                column: "AuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriveTrain",
                table: "Vehicle",
                column: "DriveTrain");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_GradeId",
                table: "Vehicle",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Price_VehicleId",
                table: "Price",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Price",
                table: "Price",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Auction",
                table: "Vehicle",
                column: "AuctionId",
                principalTable: "Auction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_DriveTrain",
                table: "Vehicle",
                column: "DriveTrain",
                principalTable: "DriveTrain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Grade",
                table: "Vehicle",
                column: "GradeId",
                principalTable: "Grade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
