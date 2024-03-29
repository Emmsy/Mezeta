﻿// <auto-generated />
using System;
using Mezeta.Infrastrucute.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mezeta.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240329082616_SugarSpiceSeedToDatabase")]
    partial class SugarSpiceSeedToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Телешкото месо е предпочитано от любителите на здравословното хранене, защото има умерено съдържание на мазнини и е особено богато на витамин B12. Шолът се намира в горната задна част на тялото и е от по-крехките меса.",
                            ImageUrl = "https://img.freepik.com/free-photo/close-up-view-green-fresh-red-raw-meat-cutting-board-pepper-lemon-black-hammer-flower-green-black-mix-color-background_179666-46997.jpg?w=740&t=st=1709646615~exp=1709647215~hmac=ab69f1429ae8a1e621d31a36fd277ec3be3c2312d7b62863e05ab4b12fac6d4d",
                            Name = "Телешки шол"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Свинското месо е едно от най-вкусните и лесни за приготвяне. Има високо съдържание на витамини – В1, В2, B3, B6 и B12. Съдържа още витамини А, Е и Д. Изключително богато на протеини и минералите – фосфор, магнезий и цинк.",
                            ImageUrl = "https://img.freepik.com/premium-photo/organic-uncooked-pork-belly-raw-bacon-meat-wooden-plate-with-thyme-wooden-background-top-view_89816-34988.jpg?w=740",
                            Name = "Свинска плешка"
                        });
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Measure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Measures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Unit = "g"
                        },
                        new
                        {
                            Id = 2,
                            Unit = "kg"
                        },
                        new
                        {
                            Id = 3,
                            Unit = "ml"
                        });
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipeIngredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IngredientId");

                    b.HasIndex("MeasureId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipesIngredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IngredientId = 1,
                            MeasureId = 1,
                            Quantity = 600.0
                        },
                        new
                        {
                            Id = 2,
                            IngredientId = 2,
                            MeasureId = 1,
                            Quantity = 400.0
                        });
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipePrepairing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ExpectedQuantity")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<double>("RawQuantity")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("RecipesPrepairings");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipeSpice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.Property<int?>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("SpiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MeasureId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("SpiceId");

                    b.ToTable("RecipesSpices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MeasureId = 1,
                            Quantity = 22.0,
                            SpiceId = 1
                        },
                        new
                        {
                            Id = 2,
                            MeasureId = 1,
                            Quantity = 0.59999999999999998,
                            SpiceId = 2
                        });
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Spice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Spices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Смес от нейодирана изпарена кухненска сол и натриев нитрит.Солта за консервиране предпазва месото от загуба на естествения му червено-розов цвят, но преди всичко предпазва хранителните продукти от развитието на нежелани микроби, главно бактериите, които произвеждат ботулиновия токсин.",
                            ImageUrl = "https://img.freepik.com/free-photo/spoon-heap-salt-table_144627-11035.jpg?t=st=1709647024~exp=1709650624~hmac=a23d4b5ef03f7d5d15c1d648d6985dea830de19ac4a5b0dac2d6552e43f8ea5b&w=1380",
                            Name = "Нитритна сол"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Използва се и като натурален консервант, тъй като има свойството да забавя окислителните процеси.",
                            ImageUrl = "https://img.freepik.com/free-photo/top-view-arrangement-with-spoon-citrus_23-2148329218.jpg?t=st=1709647433~exp=1709651033~hmac=717489b46dc56b6650c45511586ffddb720f108f7dfbb04aaa5a2e0384458cd7&w=1380",
                            Name = "Витамин Ц на прах"
                        },
                        new
                        {
                            Id = 3,
                            Description = "\"Царят на подправките\" се е доказал като един от най-забележителните фактори, влияещи върху човешката култура в историята.Черният пипер е една от най-използваните подправки в широка гама ястия готвени ястия - месо, зеленчуци, супи, дори десерти. За да запази аромата си и вкуса си, той обикновено се смила непосредствено преди добавяне в ястието.",
                            ImageUrl = "https://img.freepik.com/free-photo/closeup-shot-spoon-black-pepper-seeds-table_181624-57747.jpg?t=st=1709647103~exp=1709650703~hmac=6cae401b6145a848e2e4c707a8318a335c9e41d4ca6cf984b9b9ea8d1630744a&w=1380",
                            Name = "Черен пипер"
                        },
                        new
                        {
                            Id = 4,
                            Description = "От времето на египетските фараони, през Средновековието та чак до ден днешен кимионът е една от най-известните подправки, които намират широко приложение в кулинарията. Кимионът се отличава с доста силна миризма и специфичен натрапчив вкус, който е изключително подходящ за приготвянето на месни ястия. В наши дни, кимионът редовно се прибавя към различни колбаси от млени и кълцани меса, както и към домашни наденици и суджуци.",
                            ImageUrl = "https://img.freepik.com/free-photo/dry-fennel_501050-341.jpg?t=st=1709647257~exp=1709650857~hmac=87727d84031211c9072f2a00bef13844cd414578eecf33f9df2ffb392db97754&w=740",
                            Name = "Кимион"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Захарта спомага за привличане на добрите бактерии и за зреенето на сурово-сушените колбаси",
                            ImageUrl = "https://img.freepik.com/free-photo/world-diabetes-day-sugar-wooden-bowl-dark-surface_1150-26666.jpg?t=st=1711700263~exp=1711703863~hmac=7df68aca69e0e19008e6359acd2ec66925e493b3e157e9ed703f2a82544ca3b1&w=1380",
                            Name = "Захар"
                        });
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fab1d787-7a94-4813-845f-27aea5ac4c74",
                            ConcurrencyStamp = "d1776852-560e-4c91-8acb-ab15a649f178",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Comment", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Recipe", null)
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId");

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Recipe", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", null)
                        .WithMany("Favorites")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipeIngredient", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Measure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");

                    b.Navigation("Ingredient");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipePrepairing", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", "User")
                        .WithMany("Prepairing")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.RecipeSpice", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Measure", "UnitOfMeasure")
                        .WithMany()
                        .HasForeignKey("MeasureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Recipe", null)
                        .WithMany("Spices")
                        .HasForeignKey("RecipeId");

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.Spice", "Spice")
                        .WithMany()
                        .HasForeignKey("SpiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spice");

                    b.Navigation("UnitOfMeasure");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Mezeta.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.Recipe", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ingredients");

                    b.Navigation("Spices");
                });

            modelBuilder.Entity("Mezeta.Infrastructure.Data.Entities.User", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Prepairing");
                });
#pragma warning restore 612, 618
        }
    }
}
