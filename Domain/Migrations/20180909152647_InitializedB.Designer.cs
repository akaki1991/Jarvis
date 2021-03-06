﻿// <auto-generated />
using Domain.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Domain.Migrations
{
    [DbContext(typeof(EMobileContext))]
    [Migration("20180909152647_InitializedB")]
    partial class InitializedB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.DAO.Entities.Mobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("CPU");

                    b.Property<string>("InternalMemory");

                    b.Property<string>("Name");

                    b.Property<string>("OS");

                    b.Property<decimal>("Price");

                    b.Property<string>("RAM");

                    b.Property<string>("ScreenResolution");

                    b.Property<string>("ScreenSize");

                    b.Property<string>("Size");

                    b.Property<string>("VideoUrl");

                    b.Property<string>("Weight");

                    b.HasKey("Id");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("Domain.DAO.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MobileId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MobileId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Domain.DAO.Entities.Photo", b =>
                {
                    b.HasOne("Domain.DAO.Entities.Mobile", "Mobile")
                        .WithMany("Photos")
                        .HasForeignKey("MobileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
