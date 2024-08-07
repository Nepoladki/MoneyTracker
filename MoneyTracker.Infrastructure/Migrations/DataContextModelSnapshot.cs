﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyTracker.Infrastructure.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MoneyTracker.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MoneyTracker.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category_name");

                    b.Property<Guid?>("CreatedByUserId")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by_user_id");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("boolean")
                        .HasColumnName("is_public");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.HasIndex("CreatedByUserId")
                        .HasDatabaseName("ix_categories_created_by_user_id");

                    b.HasIndex("CategoryName", "CreatedByUserId")
                        .IsUnique()
                        .HasDatabaseName("ix_categories_category_name_created_by_user_id")
                        .HasFilter("is_public = FALSE");

                    b.HasIndex("CategoryName", "IsPublic")
                        .IsUnique()
                        .HasDatabaseName("ix_categories_category_name_is_public")
                        .HasFilter("is_public = TRUE");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.CategoryUserIcon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_categories_users_icons");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_categories_users_icons_category_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_categories_users_icons_user_id");

                    b.ToTable("categories_users_icons", (string)null);
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.Entry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("CurrencyAbbr")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("currency_abbr");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_time");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("note");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_entries");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_entries_category_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_entries_user_id");

                    b.ToTable("entries", (string)null);
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.Category", b =>
                {
                    b.HasOne("MoneyTracker.Domain.Entities.User", "User")
                        .WithMany("Categories")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_categories_users_created_by_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.CategoryUserIcon", b =>
                {
                    b.HasOne("MoneyTracker.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_categories_users_icons_categories_category_id");

                    b.HasOne("MoneyTracker.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_categories_users_icons_users_user_id");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.Entry", b =>
                {
                    b.HasOne("MoneyTracker.Domain.Entities.Category", "Category")
                        .WithMany("Entries")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_entries_categories_category_id");

                    b.HasOne("MoneyTracker.Domain.Entities.User", "User")
                        .WithMany("Entries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_entries_users_user_id");

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.Category", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("MoneyTracker.Domain.Entities.User", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
