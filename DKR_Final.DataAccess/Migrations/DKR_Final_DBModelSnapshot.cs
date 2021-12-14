﻿// <auto-generated />
using DKR_Final.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DKR_Final.DataAccess.Migrations
{
    [DbContext(typeof(DKR_Final_DB))]
    partial class DKR_Final_DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DKR_Final.DataModel.Player", b =>
                {
                    b.Property<int>("playerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("playerAge")
                        .HasColumnType("int");

                    b.Property<string>("playerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("teamId")
                        .HasColumnType("int");

                    b.HasKey("playerID");

                    b.HasIndex("teamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DKR_Final.DataModel.Team", b =>
                {
                    b.Property<int>("teamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("managerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("teamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("teamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("DKR_Final.DataModel.Player", b =>
                {
                    b.HasOne("DKR_Final.DataModel.Team", "team")
                        .WithMany("Players")
                        .HasForeignKey("teamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("team");
                });

            modelBuilder.Entity("DKR_Final.DataModel.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}