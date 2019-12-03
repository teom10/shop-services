using domain.entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace infraestructure.data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "products",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
                Name = table.Column<string>(maxLength: 50, nullable: false),
                Price = table.Column<int>(nullable: true),
                Description = table.Column<string>(nullable: false),
                Path = table.Column<string>(nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Product", x => x.Id);
            });


            migrationBuilder.CreateTable(name: "category",
                    columns: table => new
                    {
                        Id = table.Column<int>(nullable: false),
                        Name = table.Column<string>(nullable: false),
                        Code = table.Column<string>(nullable: false)
                    }, constraints: table =>
                    {
                        table.PrimaryKey("PK_Category", x => x.Id);
                    }
                );


            migrationBuilder.CreateTable(name: "sale",
                   columns: table => new
                   {
                       Id = table.Column<int>(nullable: false),
                       Date = table.Column<string>(nullable: false),
                   }, constraints: table =>
                   {
                       table.PrimaryKey("PK_Sale", x => x.Id);
                   }
               );

            migrationBuilder.CreateTable(name: "saleDetail",
                   columns: table => new
                   {
                       saleDetailId = table.Column<int>(nullable: false),
                       productId = table.Column<int>(nullable: false),
                       Count = table.Column<int>(nullable: true),
                       Total = table.Column<int>(nullable: true),
                       TotalWithTax = table.Column<int>(nullable: true),
                   }, constraints: table =>
                   {
                       table.PrimaryKey("PK_SaleDetails", x => x.saleDetailId);
                       table.ForeignKey(
                        name: "FK_SaleDetails_Sale_ProductId",
                        column: x => x.productId,
                        principalTable: "saleDetail",
                        principalColumn: "saleDetailId",
                        onDelete: ReferentialAction.Restrict);
                   }
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "products");
            migrationBuilder.DropTable(name: "category");
            migrationBuilder.DropTable(name: "sale");
            migrationBuilder.DropTable(name: "saleDetail");
            migrationBuilder.DropTable(name: "category");
        }
    }
}
