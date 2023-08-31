﻿// <auto-generated />
using System;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Auth.AuthorizedDevelopers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("NickName")
                        .HasColumnType("text")
                        .HasColumnName("developer_nickname");

                    b.HasKey("Id");

                    b.ToTable("authorized_developers", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Digimon.Buff.DigimonSkillBuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivationPercentage")
                        .HasColumnType("text")
                        .HasColumnName("activation_percentage");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_digimonskilluff_id");

                    b.ToTable("digimon_skill_buff", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ActivationPercentage = "35%",
                            Description = "Inflicts extra damage 5 seconds after the skill (600 damage base + 200 damage per skill increase (4400 max at 20/20))",
                            Name = "Flame"
                        });
                });

            modelBuilder.Entity("Core.Entities.Digimon.Digimon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AS")
                        .HasColumnType("real")
                        .HasColumnName("as");

                    b.Property<int>("AT")
                        .HasColumnType("integer")
                        .HasColumnName("at");

                    b.Property<int>("Attribute")
                        .HasColumnType("integer")
                        .HasColumnName("attribute");

                    b.Property<string>("CT")
                        .HasColumnType("text")
                        .HasColumnName("ct");

                    b.Property<bool>("CanBeRiding")
                        .HasColumnType("boolean")
                        .HasColumnName("can_riding");

                    b.Property<int>("DE")
                        .HasColumnType("integer")
                        .HasColumnName("de");

                    b.Property<int>("DS")
                        .HasColumnType("integer")
                        .HasColumnName("ds");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("EV")
                        .HasColumnType("text")
                        .HasColumnName("ev");

                    b.Property<int>("ElementalAttribute")
                        .HasColumnType("integer")
                        .HasColumnName("elemental_attribute");

                    b.Property<int>("Form")
                        .HasColumnType("integer")
                        .HasColumnName("form");

                    b.Property<int>("HP")
                        .HasColumnType("integer")
                        .HasColumnName("hp");

                    b.Property<int>("HT")
                        .HasColumnType("integer")
                        .HasColumnName("ht");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_digimon");

                    b.ToTable("digimon", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AS = 2.323f,
                            AT = 868,
                            Attribute = 1,
                            CT = "20.81%",
                            CanBeRiding = true,
                            DE = 82,
                            DS = 1196,
                            Description = "Flamedramon is a Dragon Man Digimon Armor which evolved through the power of the Digi-Egg of Courage, whose names and design are derived from Flame Dramon.",
                            EV = "21%",
                            ElementalAttribute = 0,
                            Form = 5,
                            HP = 2651,
                            HT = 515,
                            Name = "Flamedramon"
                        });
                });

            modelBuilder.Entity("Core.Entities.Digimon.DigimonSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("AnimationTime")
                        .HasColumnType("real")
                        .HasColumnName("animation_time");

                    b.Property<int>("Attribute")
                        .HasColumnType("integer")
                        .HasColumnName("attribute");

                    b.Property<int>("CoolDown")
                        .HasColumnType("integer")
                        .HasColumnName("cd");

                    b.Property<int>("DSConsumed")
                        .HasColumnType("integer")
                        .HasColumnName("ds_consumed");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int?>("DigimonSkillBuffId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("NecessarySkillPoint")
                        .HasColumnType("integer")
                        .HasColumnName("necessary_skill_point");

                    b.HasKey("Id")
                        .HasName("id_ds");

                    b.HasIndex("DigimonId");

                    b.HasIndex("DigimonSkillBuffId")
                        .IsUnique();

                    b.ToTable("digimon_skill", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnimationTime = 2.5f,
                            Attribute = 0,
                            CoolDown = 4,
                            DSConsumed = 58,
                            Description = "Surrounds itself in fire and then charge towards its opponent.\n Target randomly gets additional fire damage.",
                            DigimonId = 1,
                            DigimonSkillBuffId = 1,
                            Name = "Fire Rocket",
                            NecessarySkillPoint = 2
                        });
                });

            modelBuilder.Entity("Core.Entities.Digimon.EvolutionItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("evolution_item", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Digi-Egg of Courage",
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("Core.Entities.Digimon.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_family");

                    b.ToTable("family", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Abbreviation = "DS",
                            Description = "It is abbreviated as DS. Digimon who belong to this field are generally aquatic or polar Digimon, or those who dwell in marine areas.",
                            Name = "Deep Savers"
                        },
                        new
                        {
                            Id = 2,
                            Abbreviation = "DR",
                            Description = "It is abbreviated as DR. Digimon who belong to this field are generally Digimon of draconic descent, or those who dwell in volcanic areas.",
                            Name = "Dragon's Roar"
                        });
                });

            modelBuilder.Entity("Core.Entities.Digimon.Riding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_riding");

                    b.ToTable("riding", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "TESTEEEEEEE",
                            Name = "ModeSelector"
                        });
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonEvolutionItemIntermediate", b =>
                {
                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int>("EvolutionItemId")
                        .HasColumnType("integer");

                    b.HasKey("DigimonId", "EvolutionItemId");

                    b.HasIndex("EvolutionItemId");

                    b.ToTable("digimon_evolutionitem", (string)null);

                    b.HasData(
                        new
                        {
                            DigimonId = 1,
                            EvolutionItemId = 1
                        });
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonFamilyIntermediate", b =>
                {
                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int>("FamilyId")
                        .HasColumnType("integer");

                    b.HasKey("DigimonId", "FamilyId");

                    b.HasIndex("FamilyId");

                    b.ToTable("digimon_family", (string)null);

                    b.HasData(
                        new
                        {
                            DigimonId = 1,
                            FamilyId = 1
                        },
                        new
                        {
                            DigimonId = 1,
                            FamilyId = 2
                        });
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonRidingIntermediate", b =>
                {
                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int>("RidingId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("DigimonId", "RidingId");

                    b.HasIndex("RidingId");

                    b.ToTable("digimon_riding", (string)null);

                    b.HasData(
                        new
                        {
                            DigimonId = 1,
                            RidingId = 1,
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("Core.Entities.Tamer.Buff.TamerSkillBuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstBuffAttribute")
                        .HasColumnType("integer")
                        .HasColumnName("first_attribute");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("SeccondBuffAttribute")
                        .HasColumnType("integer")
                        .HasColumnName("seccond_attribute");

                    b.HasKey("Id")
                        .HasName("id_tsb");

                    b.ToTable("tamer_skill_buff", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstBuffAttribute = 1,
                            Name = "Rage of Keenan",
                            SeccondBuffAttribute = 3
                        });
                });

            modelBuilder.Entity("Core.Entities.Tamer.Tamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AT")
                        .HasColumnType("integer")
                        .HasColumnName("at");

                    b.Property<int>("DE")
                        .HasColumnType("integer")
                        .HasColumnName("de");

                    b.Property<int>("DS")
                        .HasColumnType("integer")
                        .HasColumnName("ds");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("HP")
                        .HasColumnType("integer")
                        .HasColumnName("hp");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TamerSkillId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("id_tamer");

                    b.HasIndex("TamerSkillId")
                        .IsUnique();

                    b.ToTable("tamer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AT = 1,
                            DE = 90,
                            DS = 80,
                            Description = "How opposed to the other members of DATS, Marcus Damon, Yoshino Fujieda, and Thomas H. Norstein, Keenan did not live in the human world, nor did he originally have a particular liking for it.",
                            HP = 10,
                            Name = "Keenan Crier",
                            TamerSkillId = 1
                        });
                });

            modelBuilder.Entity("Core.Entities.Tamer.TamerSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoolDown")
                        .HasColumnType("integer")
                        .HasColumnName("cd");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TamerSkillBuffId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("id_ts");

                    b.HasIndex("TamerSkillBuffId");

                    b.ToTable("tamer_skill", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoolDown = 2,
                            Description = "Critical hit damage increase by 100% for 30 seconds.",
                            Name = "Shock",
                            TamerSkillBuffId = 1
                        });
                });

            modelBuilder.Entity("DigimonDigimon", b =>
                {
                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int>("EvolutionsId")
                        .HasColumnType("integer");

                    b.HasKey("DigimonId", "EvolutionsId");

                    b.HasIndex("EvolutionsId");

                    b.ToTable("digimon_evolution", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Digimon.DigimonSkill", b =>
                {
                    b.HasOne("Core.Entities.Digimon.Digimon", "Digimon")
                        .WithMany("Skills")
                        .HasForeignKey("DigimonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_digimon");

                    b.HasOne("Core.Entities.Digimon.Buff.DigimonSkillBuff", "DigimonSkillBuff")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Digimon.DigimonSkill", "DigimonSkillBuffId")
                        .HasConstraintName("pk_digimon_skill_id");

                    b.Navigation("Digimon");

                    b.Navigation("DigimonSkillBuff");
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonEvolutionItemIntermediate", b =>
                {
                    b.HasOne("Core.Entities.Digimon.Digimon", "Digimon")
                        .WithMany("EvolutionItens")
                        .HasForeignKey("DigimonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Digimon.EvolutionItem", "EvolutionItem")
                        .WithMany("Digimons")
                        .HasForeignKey("EvolutionItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Digimon");

                    b.Navigation("EvolutionItem");
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonFamilyIntermediate", b =>
                {
                    b.HasOne("Core.Entities.Digimon.Digimon", "Digimon")
                        .WithMany("Families")
                        .HasForeignKey("DigimonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Digimon.Family", "Family")
                        .WithMany("Digimons")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Digimon");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Core.Entities.Intermediate.DigimonRidingIntermediate", b =>
                {
                    b.HasOne("Core.Entities.Digimon.Digimon", "Digimon")
                        .WithMany("Ridings")
                        .HasForeignKey("DigimonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Digimon.Riding", "Riding")
                        .WithMany("Digimons")
                        .HasForeignKey("RidingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Digimon");

                    b.Navigation("Riding");
                });

            modelBuilder.Entity("Core.Entities.Tamer.Tamer", b =>
                {
                    b.HasOne("Core.Entities.Tamer.TamerSkill", "TamerSkill")
                        .WithOne()
                        .HasForeignKey("Core.Entities.Tamer.Tamer", "TamerSkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TamerSkill");
                });

            modelBuilder.Entity("Core.Entities.Tamer.TamerSkill", b =>
                {
                    b.HasOne("Core.Entities.Tamer.Buff.TamerSkillBuff", "TamerSkillBuff")
                        .WithMany("TamerSkills")
                        .HasForeignKey("TamerSkillBuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_tamer_skill_buff");

                    b.Navigation("TamerSkillBuff");
                });

            modelBuilder.Entity("DigimonDigimon", b =>
                {
                    b.HasOne("Core.Entities.Digimon.Digimon", null)
                        .WithMany()
                        .HasForeignKey("DigimonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Digimon.Digimon", null)
                        .WithMany()
                        .HasForeignKey("EvolutionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Digimon.Digimon", b =>
                {
                    b.Navigation("EvolutionItens");

                    b.Navigation("Families");

                    b.Navigation("Ridings");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Core.Entities.Digimon.EvolutionItem", b =>
                {
                    b.Navigation("Digimons");
                });

            modelBuilder.Entity("Core.Entities.Digimon.Family", b =>
                {
                    b.Navigation("Digimons");
                });

            modelBuilder.Entity("Core.Entities.Digimon.Riding", b =>
                {
                    b.Navigation("Digimons");
                });

            modelBuilder.Entity("Core.Entities.Tamer.Buff.TamerSkillBuff", b =>
                {
                    b.Navigation("TamerSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
