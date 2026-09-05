using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "product_type",
                columns: table => new
                {
                    product_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_type_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_type", x => x.product_type_id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    product_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    photo_name = table.Column<string>(type: "text", nullable: true),
                    photo_uri = table.Column<string>(type: "text", nullable: true),
                    product_type_id = table.Column<int>(type: "integer", nullable: true),
                    brand_id = table.Column<int>(type: "integer", nullable: true),
                    actual_stock = table.Column<int>(type: "integer", nullable: true),
                    min_stock = table.Column<int>(type: "integer", nullable: false),
                    max_stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_brand_Product",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "brand_id");
                    table.ForeignKey(
                        name: "FK_product_type_Product",
                        column: x => x.product_type_id,
                        principalTable: "product_type",
                        principalColumn: "product_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_brand_id",
                table: "product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_product_type_id",
                table: "product",
                column: "product_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "product_type");
        }
    }
}
