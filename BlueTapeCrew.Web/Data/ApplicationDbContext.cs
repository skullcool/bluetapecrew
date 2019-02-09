using BlueTapeCrew.Web.Models;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Models.Entities.Joins;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueTapeCrew.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<AzImage> AzImages { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartImage> CartImages { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryImage> CategoryImages { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<GuestUser> GuestUsers { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<MailSetting> MailSettings { get; set; }
        public virtual DbSet<OpenGraphTag> OpenGraphTags { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PageOpenGraphTag> PageOpenGraphTags { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PayPalPayment> PayPalPayments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<SiteSetting> SiteSettings { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Style> Styles { get; set; }

        // joins
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PageOpenGraphTag>().HasKey(x => new { x.PageId, x.OpenGraphTagId });
            builder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
            builder.Entity<ProductImage>().HasKey(x => new { x.ImageId, x.ProductId });
            builder.Entity<Product>().HasMany(e => e.Styles);
            builder.Entity<Style>().HasOne(x => x.Size);
            builder.Entity<Style>().HasOne(x => x.Color);
            builder.Entity<Order>().HasMany(x => x.OrderItems);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<Cart>()
            //    .Property(e => e.CartId)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.CategoryImages)
            //    .WithRequired(e => e.Category)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Products)
            //    .WithMany(e => e.Categories)
            //    .Map(m => m.ToTable("ProductCategories").MapLeftKey("CategoryId").MapRightKey("ProductId"));

            //modelBuilder.Entity<Color>()
            //    .HasMany(e => e.Styles)
            //    .WithRequired(e => e.Color)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<GuestUser>()
            //    .Property(e => e.SessionId)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<Image>()
            //    .HasMany(e => e.Products)
            //    .WithOptional(e => e.Image)
            //    .HasForeignKey(e => e.ImageId);

            //modelBuilder.Entity<Image>()
            //    .HasMany(e => e.Products1)
            //    .WithMany(e => e.Images)
            //    .Map(m => m.ToTable("ProductImages").MapLeftKey("ImageId").MapRightKey("ProductId"));

            //modelBuilder.Entity<OpenGraphTag>()
            //    .HasMany(e => e.PageOpenGraphTags)
            //    .WithRequired(e => e.OpenGraphTag)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<OrderItem>()
            //    .Property(e => e.Price)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<OrderItem>()
            //    .Property(e => e.SubTotal)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.SessionId)
            //    .IsFixedLength()
            //    .IsUnicode(false);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.IpAddress)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.Shipping)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.Total)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<Order>()
            //    .Property(e => e.SubTotal)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderItems)
            //    .WithRequired(e => e.Order)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Page>()
            //    .HasMany(e => e.PageOpenGraphTags)
            //    .WithRequired(e => e.Page)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.AzImages)
            //    .WithRequired(e => e.Product)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.CartImages)
            //    .WithRequired(e => e.Product)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Product>()
            //    .HasMany(e => e.Reviews)
            //    .WithRequired(e => e.Product)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Review>()
            //    .Property(e => e.Rating)
            //    .HasPrecision(18, 0);

            //modelBuilder.Entity<Size>()
            //    .HasMany(e => e.Styles)
            //    .WithRequired(e => e.Size)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Style>()
            //    .Property(e => e.Price)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<Style>()
            //    .HasMany(e => e.Carts)
            //    .WithRequired(e => e.Style)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CartView>()
            //    .Property(e => e.CartId)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CartView>()
            //    .Property(e => e.Price)
            //    .HasPrecision(10, 4);

            //modelBuilder.Entity<CartView>()
            //    .Property(e => e.SubTotal)
            //    .HasPrecision(10, 4);
        }
    }
}