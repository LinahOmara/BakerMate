﻿// <auto-generated />
using System;
using BakerMate.DbContext.Presistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    [DbContext(typeof(BakerMateContext))]
    [Migration("20221121190845_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("BakerMate.Domain.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("PurchaceLocation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitOfMeasureId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UnitOfMeasureId");

                    b.ToTable("Ingredient", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Customer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Delivered")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderingDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(new DateTime(2022, 11, 21, 21, 8, 44, 842, DateTimeKind.Local).AddTicks(2856));

                    b.Property<double>("Revenue")
                        .HasColumnType("REAL");

                    b.HasKey("OrderId");

                    b.ToTable("Order", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.OrderRecipe", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("OrderRecipe", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BaseIngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BaseIngredientId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipe", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.RecipeBaseCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BaseCount")
                        .HasColumnType("REAL");

                    b.Property<int>("RecipieId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipieId");

                    b.ToTable("RecipeBaseCount", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.RecipeIngredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipieId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("IngredientQuantity")
                        .HasColumnType("REAL");

                    b.HasKey("IngredientId", "RecipieId");

                    b.HasIndex("RecipieId");

                    b.ToTable("RecipeIngredient", "BKM");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.UnitOfMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UnitOfMeasure");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Ingredient", b =>
                {
                    b.HasOne("BakerMate.Domain.Model.UnitOfMeasure", "UnitOfMeasure")
                        .WithMany("Ingredients")
                        .HasForeignKey("UnitOfMeasureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.OrderRecipe", b =>
                {
                    b.HasOne("BakerMate.Domain.Model.Order", "Order")
                        .WithMany("Recipes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakerMate.Domain.Model.Recipe", "Recipe")
                        .WithMany("Orders")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Recipe", b =>
                {
                    b.HasOne("BakerMate.Domain.Model.Ingredient", "BaseIngrediant")
                        .WithMany()
                        .HasForeignKey("BaseIngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakerMate.Domain.Model.Category", "Category")
                        .WithMany("Recipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseIngrediant");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.RecipeBaseCount", b =>
                {
                    b.HasOne("BakerMate.Domain.Model.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.RecipeIngredient", b =>
                {
                    b.HasOne("BakerMate.Domain.Model.Ingredient", "Ingredient")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BakerMate.Domain.Model.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Category", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Ingredient", b =>
                {
                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Order", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.Recipe", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("RecipeIngredients");
                });

            modelBuilder.Entity("BakerMate.Domain.Model.UnitOfMeasure", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}