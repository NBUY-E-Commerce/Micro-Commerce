using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Currenct_Type_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasterProductProperty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Master_Product_Property_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterProductProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSellerMasterCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Master_Seller_Category_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSellerMasterCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Unit_Type_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubProductProperty",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Sub_Product_Property_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Master_Product_Property_ID = table.Column<int>(nullable: false),
                    MasterProductPropertyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProductProperty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubProductProperty_MasterProductProperty_MasterProductPropertyID",
                        column: x => x.MasterProductPropertyID,
                        principalTable: "MasterProductProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSellerSubCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Master_Seller_Category_ID = table.Column<int>(nullable: false),
                    Sub_Seller_Category_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    ProductSellerMasterCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSellerSubCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductSellerSubCategory_ProductSellerMasterCategory_ProductSellerMasterCategoryID",
                        column: x => x.ProductSellerMasterCategoryID,
                        principalTable: "ProductSellerMasterCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    SubCategoryID = table.Column<int>(nullable: true),
                    CurrencyTypeID = table.Column<int>(nullable: true),
                    ProductSellerSubCategoryID = table.Column<int>(nullable: true),
                    UnitTypeID = table.Column<int>(nullable: true),
                    SubProductPropertyID = table.Column<int>(nullable: true),
                    Product_Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Available_Count = table.Column<int>(nullable: false),
                    Percentage_Discount = table.Column<float>(nullable: false),
                    Special_Offer_Price = table.Column<int>(nullable: false),
                    Special_Offer_Minimum_Quantity = table.Column<float>(nullable: false),
                    Special_Offer_Maximum_Quantity = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_CurrencyType_CurrencyTypeID",
                        column: x => x.CurrencyTypeID,
                        principalTable: "CurrencyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductSellerSubCategory_ProductSellerSubCategoryID",
                        column: x => x.ProductSellerSubCategoryID,
                        principalTable: "ProductSellerSubCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Sub_Category_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "Sub_Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_SubProductProperty_SubProductPropertyID",
                        column: x => x.SubProductPropertyID,
                        principalTable: "SubProductProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitType_UnitTypeID",
                        column: x => x.UnitTypeID,
                        principalTable: "UnitType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isDeleted = table.Column<bool>(nullable: false),
                    insertDateTime = table.Column<DateTime>(nullable: false),
                    deleteDateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    Product_Img_Path = table.Column<string>(nullable: true),
                    Product_Img_Path2 = table.Column<string>(nullable: true),
                    Product_Img_Path3 = table.Column<string>(nullable: true),
                    Product_Img_Path4 = table.Column<string>(nullable: true),
                    Product_Img_Path5 = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    isActive = table.Column<bool>(nullable: false),
                    productInImageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Product_productInImageID",
                        column: x => x.productInImageID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrencyTypeID",
                table: "Product",
                column: "CurrencyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductSellerSubCategoryID",
                table: "Product",
                column: "ProductSellerSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryID",
                table: "Product",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubProductPropertyID",
                table: "Product",
                column: "SubProductPropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitTypeID",
                table: "Product",
                column: "UnitTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImage_productInImageID",
                table: "ProductImage",
                column: "productInImageID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSellerSubCategory_ProductSellerMasterCategoryID",
                table: "ProductSellerSubCategory",
                column: "ProductSellerMasterCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProductProperty_MasterProductPropertyID",
                table: "SubProductProperty",
                column: "MasterProductPropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImage");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "CurrencyType");

            migrationBuilder.DropTable(
                name: "ProductSellerSubCategory");

            migrationBuilder.DropTable(
                name: "SubProductProperty");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "ProductSellerMasterCategory");

            migrationBuilder.DropTable(
                name: "MasterProductProperty");
        }
    }
}
