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

            modelBuilder.Entity("Core.Entities.Digimon.Buff.DigimonSkillBuff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivationPercentage")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("activation_percentage");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_digimonskilluff_id");

                    b.ToTable("digimon_skill_buff", (string)null);
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ct");

                    b.Property<int>("DE")
                        .HasColumnType("integer")
                        .HasColumnName("de");

                    b.Property<int>("DS")
                        .HasColumnType("integer")
                        .HasColumnName("ds");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("EV")
                        .IsRequired()
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_digimon");

                    b.ToTable("digimon", (string)null);
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DigimonId")
                        .HasColumnType("integer");

                    b.Property<int?>("DigimonSkillBuffId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("NecessarySkillPoint")
                        .HasColumnType("integer")
                        .HasColumnName("necessary_skill_point");

                    b.HasKey("Id")
                        .HasName("id_ds");

                    b.HasIndex("DigimonId");

                    b.HasIndex("DigimonSkillBuffId");

                    b.ToTable("digimon_skill", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Digimon.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("id_family");

                    b.ToTable("family", (string)null);
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("SeccondBuffAttribute")
                        .HasColumnType("integer")
                        .HasColumnName("seccond_attribute");

                    b.HasKey("Id")
                        .HasName("id_tsb");

                    b.ToTable("tamer_skill_buff", (string)null);
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("HP")
                        .HasColumnType("integer")
                        .HasColumnName("hp");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TamerSkillId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("id_tamer");

                    b.ToTable("tamer", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AT = 10,
                            DE = 2,
                            DS = 80,
                            Description = "MARCOOOOOOO!",
                            HP = 90,
                            Name = "Marcus Damon",
                            TamerSkillId = 0
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
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("TamerId")
                        .HasColumnType("integer");

                    b.Property<int>("TamerSkillBuffId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("id_ts");

                    b.HasIndex("TamerId")
                        .IsUnique();

                    b.HasIndex("TamerSkillBuffId");

                    b.ToTable("tamer_skill", (string)null);
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
                        .WithMany()
                        .HasForeignKey("DigimonSkillBuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("pk_digimon_skill_id");

                    b.Navigation("Digimon");

                    b.Navigation("DigimonSkillBuff");
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

            modelBuilder.Entity("Core.Entities.Tamer.TamerSkill", b =>
                {
                    b.HasOne("Core.Entities.Tamer.Tamer", "Tamer")
                        .WithOne("TamerSkill")
                        .HasForeignKey("Core.Entities.Tamer.TamerSkill", "TamerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_tamer");

                    b.HasOne("Core.Entities.Tamer.Buff.TamerSkillBuff", "TamerSkillBuff")
                        .WithMany("TamerSkills")
                        .HasForeignKey("TamerSkillBuffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("id_tamer_skill_buff");

                    b.Navigation("Tamer");

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
                    b.Navigation("Families");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("Core.Entities.Digimon.Family", b =>
                {
                    b.Navigation("Digimons");
                });

            modelBuilder.Entity("Core.Entities.Tamer.Buff.TamerSkillBuff", b =>
                {
                    b.Navigation("TamerSkills");
                });

            modelBuilder.Entity("Core.Entities.Tamer.Tamer", b =>
                {
                    b.Navigation("TamerSkill")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
