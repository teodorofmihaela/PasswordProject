﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PasswordApi.Infrastructure.Data;

#nullable disable

namespace PasswordApi.Presentation.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PasswordApi.Core.Models.Account", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TemporaryPasswordId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId");

                    b.HasIndex("TemporaryPasswordId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("PasswordApi.Core.Models.TemporaryPassword", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("ExpirationTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TemporaryPasswords");
                });

            modelBuilder.Entity("PasswordApi.Core.Models.Account", b =>
                {
                    b.HasOne("PasswordApi.Core.Models.TemporaryPassword", "TemporaryPassword")
                        .WithOne("Account")
                        .HasForeignKey("PasswordApi.Core.Models.Account", "TemporaryPasswordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemporaryPassword");
                });

            modelBuilder.Entity("PasswordApi.Core.Models.TemporaryPassword", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
