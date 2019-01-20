﻿// <auto-generated />
using System;
using BlueTapeCrew.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlueTapeCrew.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190120191110_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlueTapeCrew.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PostalCode");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("State");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("User");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.AccessToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Expiration");

                    b.Property<string>("Token");

                    b.Property<int>("TokenType");

                    b.HasKey("Id");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.AzImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .IsRequired();

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("AzImages");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CartId")
                        .IsRequired()
                        .HasMaxLength(68);

                    b.Property<int>("Count");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ProductId");

                    b.Property<int>("StyleId");

                    b.HasKey("Id");

                    b.HasIndex("StyleId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.CartImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ImageData")
                        .IsRequired();

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CartImages");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.CartView", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("CartId")
                        .HasMaxLength(68);

                    b.Property<int>("Quantity");

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName")
                        .HasMaxLength(255);

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<int>("StyleId");

                    b.Property<string>("ColorText")
                        .HasMaxLength(25);

                    b.Property<string>("StyleText")
                        .HasMaxLength(60);

                    b.Property<string>("Description");

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("LinkName")
                        .HasMaxLength(255);

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("smallmoney");

                    b.HasKey("Id", "CartId", "Quantity", "ProductId", "ProductName", "Price", "StyleId", "ColorText", "StyleText");

                    b.ToTable("CartView");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ImageId");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2083);

                    b.Property<bool>("Published");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.CategoryImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<byte[]>("ImageData");

                    b.Property<string>("MimeType")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryImages");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorText")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.GuestUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .HasMaxLength(75);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<string>("FirstName")
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .HasMaxLength(60);

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(20);

                    b.Property<string>("SessionId")
                        .HasMaxLength(24);

                    b.Property<string>("State")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("GuestUsers");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("Height");

                    b.Property<byte[]>("ImageData")
                        .IsRequired();

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<short?>("Width");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Paid");

                    b.Property<string>("SessionId");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Joins.ProductCategory", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Joins.ProductImage", b =>
                {
                    b.Property<int>("ImageId");

                    b.Property<int>("ProductId");

                    b.HasKey("ImageId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.MailSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Port");

                    b.Property<string>("SmtpServer")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("MailSettings");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.OpenGraphTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Property")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("OpenGraphTags");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FirstName")
                        .HasMaxLength(255);

                    b.Property<int>("InvoiceId");

                    b.Property<string>("IpAddress")
                        .HasMaxLength(15);

                    b.Property<string>("LastName")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .HasMaxLength(255);

                    b.Property<string>("SessionId")
                        .HasMaxLength(24);

                    b.Property<decimal?>("Shipping")
                        .HasColumnType("smallmoney");

                    b.Property<string>("State")
                        .HasMaxLength(255);

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("smallmoney");

                    b.Property<decimal?>("Total")
                        .HasColumnType("smallmoney");

                    b.Property<string>("UserName")
                        .HasMaxLength(255);

                    b.Property<string>("Zip")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("OrderId");

                    b.Property<decimal?>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("SubTotal")
                        .HasColumnType("smallmoney");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.PageOpenGraphTag", b =>
                {
                    b.Property<int>("PageId");

                    b.Property<int>("OpenGraphTagId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("PageId", "OpenGraphTagId");

                    b.HasIndex("OpenGraphTagId");

                    b.ToTable("PageOpenGraphTags");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.PayPalPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Amt")
                        .HasMaxLength(255);

                    b.Property<string>("Cc")
                        .HasMaxLength(255);

                    b.Property<string>("Tx")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PayPalPayments");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ImageId");

                    b.Property<string>("LinkName")
                        .HasMaxLength(255);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreated");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Rating");

                    b.Property<string>("ReviewText")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.SiteSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutUs");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ContactEmailAddress");

                    b.Property<string>("ContactPhoneNumber");

                    b.Property<string>("CopyrightLinktext");

                    b.Property<string>("CopyrightText");

                    b.Property<string>("CopyrightUrl");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("FaceBookUrl");

                    b.Property<string>("FacebookAppId")
                        .HasMaxLength(255);

                    b.Property<string>("FacebookClientId");

                    b.Property<string>("FacebookClientSecret");

                    b.Property<decimal>("FlatShippingRate");

                    b.Property<decimal>("FreeShippingThreshold");

                    b.Property<string>("GoogleClientId")
                        .HasMaxLength(255);

                    b.Property<string>("GoogleClientSecret")
                        .HasMaxLength(255);

                    b.Property<string>("InstagramClientId");

                    b.Property<string>("InstagramClientSecret");

                    b.Property<string>("Keywords")
                        .IsRequired();

                    b.Property<string>("LinkedInUrl");

                    b.Property<string>("MailChimpApiKey")
                        .HasMaxLength(255);

                    b.Property<string>("MailChimpListId")
                        .HasMaxLength(50);

                    b.Property<string>("MicrosoftClientId");

                    b.Property<string>("MicrosoftClientSecret");

                    b.Property<string>("PaypalApiUsername")
                        .HasMaxLength(100);

                    b.Property<string>("PaypalClientId")
                        .HasMaxLength(100);

                    b.Property<string>("PaypalClientSecret")
                        .HasMaxLength(100);

                    b.Property<string>("PaypalSandBoxClientId");

                    b.Property<string>("PaypalSandBoxSecret");

                    b.Property<string>("PaypalSandboxAccount");

                    b.Property<string>("SiteLogoUrl")
                        .HasMaxLength(255);

                    b.Property<string>("SiteTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SiteUrl")
                        .HasMaxLength(255);

                    b.Property<string>("SmtpHost");

                    b.Property<string>("SmtpPassword");

                    b.Property<int>("SmtpPort");

                    b.Property<string>("SmtpUsername");

                    b.Property<string>("TwitterClientId");

                    b.Property<string>("TwitterClientSecret");

                    b.Property<string>("TwitterUrl");

                    b.Property<string>("TwitterWidgetId")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SiteSettings");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SizeOrder");

                    b.Property<string>("SizeText")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ColorId");

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<int>("ProductId");

                    b.Property<int>("SizeId");

                    b.HasKey("Id");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.StyleView", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("ProductId");

                    b.Property<int>("SizeId");

                    b.Property<int>("SizeOrder");

                    b.Property<string>("SizeText")
                        .HasMaxLength(20);

                    b.Property<int>("ColorId");

                    b.Property<string>("ColorText")
                        .HasMaxLength(25);

                    b.Property<decimal>("Price")
                        .HasColumnType("smallmoney");

                    b.Property<string>("StyleText")
                        .HasMaxLength(48);

                    b.HasKey("Id", "ProductId", "SizeId", "SizeOrder", "SizeText", "ColorId", "ColorText", "Price", "StyleText");

                    b.ToTable("StyleView");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.AzImage", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("AzImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Cart", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Style", "Style")
                        .WithMany("Carts")
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.CartImage", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("CartImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Category", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Image", "Image")
                        .WithMany("Categories")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.CategoryImage", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Category", "Category")
                        .WithMany("CategoryImages")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Joins.ProductCategory", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Joins.ProductImage", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Order", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.OrderItem", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.PageOpenGraphTag", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.OpenGraphTag", "OpenGraphTag")
                        .WithMany("PageOpenGraphTags")
                        .HasForeignKey("OpenGraphTagId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Page", "Page")
                        .WithMany("PageOpenGraphTags")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Product", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Image", "Image")
                        .WithMany("Products")
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Review", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BlueTapeCrew.Web.Models.Entities.Style", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Color", "Color")
                        .WithMany("Styles")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Product", "Product")
                        .WithMany("Styles")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.Entities.Size", "Size")
                        .WithMany("Styles")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BlueTapeCrew.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BlueTapeCrew.Web.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
