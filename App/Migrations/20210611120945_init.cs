using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CategorisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_furnitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_furnitures_Categories_CategorisId",
                        column: x => x.CategorisId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quntity = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardItems_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "NameOfCategory" },
                values: new object[,]
                {
                    { 1, "Sofa and tabel" },
                    { 2, "Carpet" }
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "Address", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Dammam", "Fatma.Alqhtnay94@hotmail.com", "Fatimah", "Alqhtnay", 555906886 });

            migrationBuilder.InsertData(
                table: "furnitures",
                columns: new[] { "Id", "CategorisId", "Category", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, null, 0, "https://www.ikea.com/sa/en/images/products/gammalbyn-3-seat-sofa-beige__0868906_pe781416_s5.jpg", "Sofa ", 3000.0 },
                    { 2, null, 0, "https://media.wired.com/photos/5f6e50f30cb5c0e55736d793/1:1/w_1800,h_1800,c_limit/Gear-Benchmade-Modern-Tyler-Sofa-SOURCE-Benchmade-Modern.jpg", "Sofa", 2500.0 },
                    { 3, null, 0, "https://assets.weimgs.com/weimgs/rk/images/wcm/products/202115/0104/tripod-dining-table-walnut-c.jpg", "Tabel with 2 seats", 600.0 },
                    { 4, null, 0, "https://www.woods-furniture.co.uk/images/products/large/7710.jpg", "Sofa 3 Seater  ", 4000.0 },
                    { 5, null, 0, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/walmart-sofa-1538774260.jpg?crop=0.923xw:0.462xh;0.0657xw,0.401xh&resize=1200:*", "Sofa", 700.0 },
                    { 6, null, 0, "https://cdn.shopify.com/s/files/1/0104/1524/3330/products/zoco-home-furnitures-furnitures-tables-round-dining-table-140cm-tab1014-11553669251138_1000x1000.png?v=1606681288", "Round dining table", 600.0 }
                });

            migrationBuilder.InsertData(
                table: "CardItems",
                columns: new[] { "Id", "CustomerId", "Quntity", "TotalCost" },
                values: new object[] { 1, 1, 5, 30000 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "CustomerId", "PaymentType" },
                values: new object[] { 1, 22, 1, "Visa Card" });

            migrationBuilder.CreateIndex(
                name: "IX_CardItems_CustomerId",
                table: "CardItems",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_furnitures_CategorisId",
                table: "furnitures",
                column: "CategorisId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerId",
                table: "Payments",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardItems");

            migrationBuilder.DropTable(
                name: "furnitures");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
