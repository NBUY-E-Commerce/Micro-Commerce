using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace B_Commerce.ProductService.Migrations
{
    public partial class ModelReadjusmentSimpleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CurrencyType_CurrencyTypeID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductSellerSubCategory_ProductSellerSubCategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Sub_Category_SubCategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubProductProperty_SubProductPropertyID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UnitType_UnitTypeID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImage_Product_productInImageID",
                table: "ProductImage");

            migrationBuilder.DropTable(
                name: "CurrencyType");

            migrationBuilder.DropTable(
                name: "ProductSellerSubCategory");

            migrationBuilder.DropTable(
                name: "Sub_Category");

            migrationBuilder.DropTable(
                name: "SubProductProperty");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "ProductSellerMasterCategory");

            migrationBuilder.DropTable(
                name: "Master_Category");

            migrationBuilder.DropTable(
                name: "MasterProductProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage");

            migrationBuilder.DropIndex(
                name: "IX_ProductImage_productInImageID",
                table: "ProductImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CurrencyTypeID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductSellerSubCategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubCategoryID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubProductPropertyID",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UnitTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Product_Img_Path",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Product_Img_Path2",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Product_Img_Path3",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Product_Img_Path4",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Product_Img_Path5",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "productInImageID",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Available_Count",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CurrencyTypeID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Percentage_Discount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductSellerSubCategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Product_Name",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Special_Offer_Maximum_Quantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Special_Offer_Minimum_Quantity",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Special_Offer_Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubProductPropertyID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UnitTypeID",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductImage",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ProductImages",
                newName: "DeletedImage");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "ProductImages",
                newName: "ActiveImage");

            migrationBuilder.RenameColumn(
                name: "insertDateTime",
                table: "ProductImages",
                newName: "I_DateTime");

            migrationBuilder.RenameColumn(
                name: "deleteDateTime",
                table: "ProductImages",
                newName: "D_DateTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductImages",
                newName: "ImageDesc");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ProductImages",
                newName: "ProductImageID");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Products",
                newName: "DeletedProduct");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Products",
                newName: "ActiveProduct");

            migrationBuilder.RenameColumn(
                name: "insertDateTime",
                table: "Products",
                newName: "I_DateTime");

            migrationBuilder.RenameColumn(
                name: "deleteDateTime",
                table: "Products",
                newName: "D_DateTime");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "ProductDesc");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.AlterColumn<bool>(
                name: "DeletedImage",
                table: "ProductImages",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ActiveImage",
                table: "ProductImages",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDesc",
                table: "ProductImages",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProductImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                table: "ProductImages",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<bool>(
                name: "DeletedProduct",
                table: "Products",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ActiveProduct",
                table: "Products",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDesc",
                table: "Products",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AvailableCount",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PercentageDiscount",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SpecialOfferMaximumQuantity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SpecialOfferMinimumQuantity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpecialOfferPrice",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "ProductImageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeletedCategory = table.Column<bool>(nullable: false, defaultValue: false),
                    I_DateTime = table.Column<DateTime>(nullable: false),
                    D_DateTime = table.Column<DateTime>(nullable: true),
                    insertUserId = table.Column<int>(nullable: true),
                    deleteUserId = table.Column<int>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryDesc = table.Column<string>(maxLength: 250, nullable: true),
                    MCID = table.Column<int>(nullable: true),
                    SCID = table.Column<int>(nullable: true),
                    ActiveCategory = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoryID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductID",
                table: "CategoryProduct",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductID",
                table: "ProductImages");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductID",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "AvailableCount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PercentageDiscount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialOfferMaximumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialOfferMinimumQuantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecialOfferPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "URL",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "ProductImage");

            migrationBuilder.RenameColumn(
                name: "DeletedProduct",
                table: "Product",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "ActiveProduct",
                table: "Product",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "I_DateTime",
                table: "Product",
                newName: "insertDateTime");

            migrationBuilder.RenameColumn(
                name: "D_DateTime",
                table: "Product",
                newName: "deleteDateTime");

            migrationBuilder.RenameColumn(
                name: "ProductDesc",
                table: "Product",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Product",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DeletedImage",
                table: "ProductImage",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "ActiveImage",
                table: "ProductImage",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "I_DateTime",
                table: "ProductImage",
                newName: "insertDateTime");

            migrationBuilder.RenameColumn(
                name: "D_DateTime",
                table: "ProductImage",
                newName: "deleteDateTime");

            migrationBuilder.RenameColumn(
                name: "ImageDesc",
                table: "ProductImage",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProductImageID",
                table: "ProductImage",
                newName: "ID");

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Product",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Available_Count",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyTypeID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Percentage_Discount",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ProductSellerSubCategoryID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Name",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Special_Offer_Maximum_Quantity",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Special_Offer_Minimum_Quantity",
                table: "Product",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Special_Offer_Price",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubProductPropertyID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitTypeID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "ProductImage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "ProductImage",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Img_Path",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Img_Path2",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Img_Path3",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Img_Path4",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_Img_Path5",
                table: "ProductImage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "productInImageID",
                table: "ProductImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImage",
                table: "ProductImage",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CurrencyType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Currenct_Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Master_Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MasterProductProperty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Master_Product_Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterProductProperty", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSellerMasterCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Master_Seller_Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSellerMasterCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit_Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sub_Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Master_Category_ID = table.Column<int>(type: "int", nullable: false),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sub_Category_Master_Category_Master_Category_ID",
                        column: x => x.Master_Category_ID,
                        principalTable: "Master_Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProductProperty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterProductPropertyID = table.Column<int>(type: "int", nullable: true),
                    Master_Product_Property_ID = table.Column<int>(type: "int", nullable: false),
                    Sub_Product_Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Master_Seller_Category_ID = table.Column<int>(type: "int", nullable: false),
                    ProductSellerMasterCategoryID = table.Column<int>(type: "int", nullable: true),
                    Sub_Seller_Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deleteDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleteUserId = table.Column<int>(type: "int", nullable: true),
                    insertDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    insertUserId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Sub_Category_Master_Category_ID",
                table: "Sub_Category",
                column: "Master_Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProductProperty_MasterProductPropertyID",
                table: "SubProductProperty",
                column: "MasterProductPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CurrencyType_CurrencyTypeID",
                table: "Product",
                column: "CurrencyTypeID",
                principalTable: "CurrencyType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductSellerSubCategory_ProductSellerSubCategoryID",
                table: "Product",
                column: "ProductSellerSubCategoryID",
                principalTable: "ProductSellerSubCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Sub_Category_SubCategoryID",
                table: "Product",
                column: "SubCategoryID",
                principalTable: "Sub_Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubProductProperty_SubProductPropertyID",
                table: "Product",
                column: "SubProductPropertyID",
                principalTable: "SubProductProperty",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UnitType_UnitTypeID",
                table: "Product",
                column: "UnitTypeID",
                principalTable: "UnitType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImage_Product_productInImageID",
                table: "ProductImage",
                column: "productInImageID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
