using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "digimon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    @as = table.Column<float>(name: "as", type: "real", nullable: false),
                    ct = table.Column<string>(type: "text", nullable: true),
                    ht = table.Column<int>(type: "integer", nullable: false),
                    ev = table.Column<string>(type: "text", nullable: true),
                    form = table.Column<int>(type: "integer", nullable: false),
                    attribute = table.Column<int>(type: "integer", nullable: false),
                    elemental_attribute = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    hp = table.Column<int>(type: "integer", nullable: false),
                    ds = table.Column<int>(type: "integer", nullable: false),
                    de = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_digimon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "digimon_skill_buff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    activation_percentage = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_digimonskilluff_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Abbreviation = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tamer_skill_buff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    first_attribute = table.Column<int>(type: "integer", nullable: false),
                    seccond_attribute = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_tsb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "digimon_evolution",
                columns: table => new
                {
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    EvolutionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digimon_evolution", x => new { x.DigimonId, x.EvolutionsId });
                    table.ForeignKey(
                        name: "FK_digimon_evolution_digimon_DigimonId",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_digimon_evolution_digimon_EvolutionsId",
                        column: x => x.EvolutionsId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "digimon_skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    attribute = table.Column<int>(type: "integer", nullable: false),
                    cd = table.Column<int>(type: "integer", nullable: false),
                    ds_consumed = table.Column<int>(type: "integer", nullable: false),
                    necessary_skill_point = table.Column<int>(type: "integer", nullable: false),
                    animation_time = table.Column<float>(type: "real", nullable: false),
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    DigimonSkillBuffId = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_ds", x => x.Id);
                    table.ForeignKey(
                        name: "id_digimon",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "pk_digimon_skill_id",
                        column: x => x.DigimonSkillBuffId,
                        principalTable: "digimon_skill_buff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "digimon_family",
                columns: table => new
                {
                    DigimonId = table.Column<int>(type: "integer", nullable: false),
                    FamilyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_digimon_family", x => new { x.DigimonId, x.FamilyId });
                    table.ForeignKey(
                        name: "FK_digimon_family_digimon_DigimonId",
                        column: x => x.DigimonId,
                        principalTable: "digimon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_digimon_family_family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "family",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tamer_skill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cd = table.Column<int>(type: "integer", nullable: false),
                    TamerSkillBuffId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_ts", x => x.Id);
                    table.ForeignKey(
                        name: "id_tamer_skill_buff",
                        column: x => x.TamerSkillBuffId,
                        principalTable: "tamer_skill_buff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tamer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TamerSkillId = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    hp = table.Column<int>(type: "integer", nullable: false),
                    ds = table.Column<int>(type: "integer", nullable: false),
                    de = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_tamer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tamer_tamer_skill_TamerSkillId",
                        column: x => x.TamerSkillId,
                        principalTable: "tamer_skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tamer_skill_buff",
                columns: new[] { "Id", "first_attribute", "name", "seccond_attribute" },
                values: new object[] { 1, 1, "Rage of Keenan", 3 });

            migrationBuilder.InsertData(
                table: "tamer_skill",
                columns: new[] { "Id", "cd", "description", "name", "TamerSkillBuffId" },
                values: new object[] { 1, 2, "Critical hit damage increase by 100% for 30 seconds.", "Shock", 1 });

            migrationBuilder.InsertData(
                table: "tamer",
                columns: new[] { "Id", "at", "de", "ds", "description", "hp", "name", "TamerSkillId" },
                values: new object[] { 1, 1, 90, 80, "How opposed to the other members of DATS, Marcus Damon, Yoshino Fujieda, and Thomas H. Norstein, Keenan did not live in the human world, nor did he originally have a particular liking for it.", 10, "Keenan Crier", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_digimon_evolution_EvolutionsId",
                table: "digimon_evolution",
                column: "EvolutionsId");

            migrationBuilder.CreateIndex(
                name: "IX_digimon_family_FamilyId",
                table: "digimon_family",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_digimon_skill_DigimonId",
                table: "digimon_skill",
                column: "DigimonId");

            migrationBuilder.CreateIndex(
                name: "IX_digimon_skill_DigimonSkillBuffId",
                table: "digimon_skill",
                column: "DigimonSkillBuffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tamer_TamerSkillId",
                table: "tamer",
                column: "TamerSkillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tamer_skill_TamerSkillBuffId",
                table: "tamer_skill",
                column: "TamerSkillBuffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "digimon_evolution");

            migrationBuilder.DropTable(
                name: "digimon_family");

            migrationBuilder.DropTable(
                name: "digimon_skill");

            migrationBuilder.DropTable(
                name: "tamer");

            migrationBuilder.DropTable(
                name: "family");

            migrationBuilder.DropTable(
                name: "digimon");

            migrationBuilder.DropTable(
                name: "digimon_skill_buff");

            migrationBuilder.DropTable(
                name: "tamer_skill");

            migrationBuilder.DropTable(
                name: "tamer_skill_buff");
        }
    }
}
