﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Projeto_Final.Models;

namespace Projeto_Final.Migrations
{
    [DbContext(typeof(UserManagementContext))]
    partial class UserManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Projeto_Final.Models.Pets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Adopted")
                        .HasColumnType("boolean");

                    b.Property<int>("Age_months")
                        .HasColumnType("integer");

                    b.Property<int>("Age_years")
                        .HasColumnType("integer");

                    b.Property<string>("Animal")
                        .HasColumnType("text");

                    b.Property<string>("Breed")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("New_ownerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Publication_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("New_ownerId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Projeto_Final.Models.Photo", b =>
                {
                    b.Property<int>("Photo_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pet_name")
                        .HasColumnType("text");

                    b.Property<int?>("PetsId")
                        .HasColumnType("integer");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("text");

                    b.Property<DateTime>("Publication_date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Photo_Id");

                    b.HasIndex("PetsId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Projeto_Final.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Adopted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CEP")
                        .HasColumnType("text");

                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<bool>("Donated")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("House_number")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Projeto_Final.Models.Pets", b =>
                {
                    b.HasOne("Projeto_Final.Models.Users", "New_owner")
                        .WithMany()
                        .HasForeignKey("New_ownerId");

                    b.Navigation("New_owner");
                });

            modelBuilder.Entity("Projeto_Final.Models.Photo", b =>
                {
                    b.HasOne("Projeto_Final.Models.Pets", null)
                        .WithMany("Photos")
                        .HasForeignKey("PetsId");
                });

            modelBuilder.Entity("Projeto_Final.Models.Pets", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
