using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marque",
                columns: table => new
                {
                    id_marque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_marque = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marque", x => x.id_marque);
                });

            migrationBuilder.CreateTable(
                name: "TypeProduit",
                columns: table => new
                {
                    id_type_produit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_type_produit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProduit", x => x.id_type_produit);
                });

            migrationBuilder.CreateTable(
                name: "produit",
                columns: table => new
                {
                    id_produit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_produit = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    nom_photo = table.Column<string>(type: "text", nullable: false),
                    uri_photo = table.Column<string>(type: "text", nullable: false),
                    id_type_produit = table.Column<int>(type: "integer", nullable: true),
                    id_marque = table.Column<int>(type: "integer", nullable: true),
                    stock_reel = table.Column<int>(type: "integer", nullable: false),
                    stock_min = table.Column<int>(type: "integer", nullable: false),
                    stock_max = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produit", x => x.id_produit);
                    table.ForeignKey(
                        name: "FK_produits_marque",
                        column: x => x.id_marque,
                        principalTable: "Marque",
                        principalColumn: "id_marque");
                    table.ForeignKey(
                        name: "FK_produits_type_produit",
                        column: x => x.id_type_produit,
                        principalTable: "TypeProduit",
                        principalColumn: "id_type_produit");
                });

            migrationBuilder.CreateIndex(
                name: "IX_produit_id_marque",
                table: "produit",
                column: "id_marque");

            migrationBuilder.CreateIndex(
                name: "IX_produit_id_type_produit",
                table: "produit",
                column: "id_type_produit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produit");

            migrationBuilder.DropTable(
                name: "Marque");

            migrationBuilder.DropTable(
                name: "TypeProduit");
        }
    }
}
