using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Itens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digimon_evolutionitem");

            migrationBuilder.DropTable(
                name: "digimon_riding");

            migrationBuilder.DropTable(
                name: "evolution_item");

            migrationBuilder.DropTable(
                name: "riding");

            migrationBuilder.CreateTable(
                name: "item_type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemTypeId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_item_item_type_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "item_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "digimon_item",
                columns: table => new
                {
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digimon_item", x => new { x.DigimonId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_digimon_item_digimon_DigimonId",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_digimon_item_item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "item_type",
                columns: new[] { "Id", "description", "name" },
                values: new object[,]
                {
                    { 1, "Montaria", "Digivolução" },
                    { 2, "Evolução", "Digivolução" }
                });

            migrationBuilder.InsertData(
                table: "item",
                columns: new[] { "Id", "description", "ItemTypeId", "name" },
                values: new object[,]
                {
                    { 1, "Prolongue a evolução do modo montaria", 1, "Modo Seletor" },
                    { 2, "Forçar a expansão do slot de evolução do Digimon", 2, "Evoluter" }
                });

            migrationBuilder.InsertData(
                table: "digimon_item",
                columns: new[] { "DigimonId", "ItemId", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_digimon_item_ItemId",
                table: "digimon_item",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_item_ItemTypeId",
                table: "item",
                column: "ItemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digimon_item");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "item_type");

            migrationBuilder.CreateTable(
                name: "evolution_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "riding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_riding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "digimon_evolutionitem",
                columns: table => new
                {
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    EvolutionItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digimon_evolutionitem", x => new { x.DigimonId, x.EvolutionItemId });
                    table.ForeignKey(
                        name: "FK_digimon_evolutionitem_digimon_DigimonId",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_digimon_evolutionitem_evolution_item_EvolutionItemId",
                        column: x => x.EvolutionItemId,
                        principalTable: "evolution_item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "digimon_riding",
                columns: table => new
                {
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    RidingId = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digimon_riding", x => new { x.DigimonId, x.RidingId });
                    table.ForeignKey(
                        name: "FK_digimon_riding_digimon_DigimonId",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_digimon_riding_riding_RidingId",
                        column: x => x.RidingId,
                        principalTable: "riding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "evolution_item",
                columns: new[] { "Id", "name", "quantity" },
                values: new object[] { 1, "Digi-Egg of Courage", 1 });

            migrationBuilder.InsertData(
                table: "riding",
                columns: new[] { "Id", "description", "name" },
                values: new object[] { 1, "TESTEEEEEEE", "ModeSelector" });

            migrationBuilder.InsertData(
                table: "digimon_evolutionitem",
                columns: new[] { "DigimonId", "EvolutionItemId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "digimon_riding",
                columns: new[] { "DigimonId", "RidingId", "quantity" },
                values: new object[] { 1, 1, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_digimon_evolutionitem_EvolutionItemId",
                table: "digimon_evolutionitem",
                column: "EvolutionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_digimon_riding_RidingId",
                table: "digimon_riding",
                column: "RidingId");
        }
    }
}
