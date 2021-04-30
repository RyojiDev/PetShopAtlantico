﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PetshopAtlantico.DataBaseAccess.Entity;

namespace PetShopAtlanticoWebApi.Migrations
{
    [DbContext(typeof(PetShopDbContext))]
    [Migration("20210430001130_add-name")]
    partial class addname
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PetShopAtlanticoWebApi.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdPetOwner")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PetHealth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PetOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PetPhotograph")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PetOwnerId")
                        .IsUnique();

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetShopAtlanticoWebApi.Models.PetOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPet")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("PetOwner");
                });

            modelBuilder.Entity("PetShopAtlanticoWebApi.Models.Pet", b =>
                {
                    b.HasOne("PetShopAtlanticoWebApi.Models.PetOwner", "PetOwner")
                        .WithOne()
                        .HasForeignKey("PetShopAtlanticoWebApi.Models.Pet", "PetOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetOwner");
                });

            modelBuilder.Entity("PetShopAtlanticoWebApi.Models.PetOwner", b =>
                {
                    b.HasOne("PetShopAtlanticoWebApi.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("PetId");

                    b.Navigation("Pet");
                });
#pragma warning restore 612, 618
        }
    }
}
