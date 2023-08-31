using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Riding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "can_riding",
                table: "digimon",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            // migrationBuilder.CreateTable(
            //     name: "authorized_developers",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         developer_nickname = table.Column<string>(type: "text", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_authorized_developers", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "EvolutionItem",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "integer", nullable: false)
            //             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //         Name = table.Column<string>(type: "text", nullable: true),
            //         Drop = table.Column<bool>(type: "boolean", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_EvolutionItem", x => x.Id);
            //     });

            migrationBuilder.CreateTable(
                name: "riding",
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

            migrationBuilder.UpdateData(
                table: "digimon",
                keyColumn: "Id",
                keyValue: 1,
                column: "can_riding",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_digimon_riding_RidingId",
                table: "digimon_riding",
                column: "RidingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "authorized_developers");

            migrationBuilder.DropTable(
                name: "digimon_riding");

            // migrationBuilder.DropTable(
            //     name: "EvolutionItem");

            migrationBuilder.DropTable(
                name: "riding");

            migrationBuilder.DropColumn(
                name: "can_riding",
                table: "digimon");
        }
    }
}
