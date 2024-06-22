using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data;

public partial class DbClothesShopContext : DbContext
{
    public DbClothesShopContext()
    {
    }

    public DbClothesShopContext(DbContextOptions<DbClothesShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbDiscount> TbDiscounts { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbOrderItem> TbOrderItems { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    public virtual DbSet<TbReview> TbReviews { get; set; }

    public virtual DbSet<TbSupplier> TbSuppliers { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbWishlist> TbWishlists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.IdCategory);

            entity.ToTable("tb_Category");

            entity.Property(e => e.IdCategory)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Category");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbDiscount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Discount");

            entity.Property(e => e.CuponCode)
                .HasMaxLength(50)
                .HasColumnName("Cupon_code");
            entity.Property(e => e.DiscountPercent)
                .HasColumnType("decimal(4, 0)")
                .HasColumnName("Discount_percent");
            entity.Property(e => e.IdCupon).HasColumnName("ID_Cupon");
            entity.Property(e => e.ValidFrom)
                .HasColumnType("datetime")
                .HasColumnName("Valid_from");
            entity.Property(e => e.ValidUntil)
                .HasColumnType("datetime")
                .HasColumnName("Valid_until");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("tb_Orders");

            entity.Property(e => e.IdOrder)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Order");
            entity.Property(e => e.IdOrderItems)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Order_items");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_User");
            entity.Property(e => e.OrderDate).HasColumnName("Order_date");
            entity.Property(e => e.TotalAmount).HasColumnName("Total_amount");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Orders_tb_User");
        });

        modelBuilder.Entity<TbOrderItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Order_items");

            entity.Property(e => e.IdCupon).HasColumnName("ID_Cupon");
            entity.Property(e => e.IdOrder)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Order");
            entity.Property(e => e.IdOrderItems)
                .HasMaxLength(50)
                .HasColumnName("ID_Order_items");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.Quantity).HasColumnType("text");
            entity.Property(e => e.UnitPrice).HasColumnName("Unit_price");

            entity.HasOne(d => d.IdOrderNavigation).WithMany()
                .HasForeignKey(d => d.IdOrder)
                .HasConstraintName("FK_tb_Order_items_tb_Orders");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_tb_Order_items_tb_Products");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK_Products");

            entity.ToTable("tb_Products");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.IdCategory)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Category");
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Size).HasColumnType("text");
            entity.Property(e => e.StockQuantity).HasColumnName("Stock_quantity");
            entity.Property(e => e.Type).HasColumnType("text");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("Updated_at");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.TbProducts)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_tb_Products_tb_Category");
        });

        modelBuilder.Entity<TbReview>(entity =>
        {
            entity.HasKey(e => e.IdReview);

            entity.ToTable("tb_Review");

            entity.Property(e => e.IdReview)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Review");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_User");
            entity.Property(e => e.Rating)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ReviewDate)
                .HasColumnType("datetime")
                .HasColumnName("Review_date");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_tb_Review_tb_Products");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.TbReviews)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Review_tb_User");
        });

        modelBuilder.Entity<TbSupplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PK_Table_1");

            entity.ToTable("tb_Supplier");

            entity.Property(e => e.IdSupplier).HasColumnName("ID_Supplier");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.SuppilerName)
                .HasMaxLength(50)
                .HasColumnName("Suppiler_name");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("tb_User");

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("First Name");
            entity.Property(e => e.IdOrder)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Order");
            entity.Property(e => e.IdReview)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Review");
            entity.Property(e => e.IdWishlist)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Wishlist");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Last Name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbWishlist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Wishlist");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Product");
            entity.Property(e => e.IdUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_User");
            entity.Property(e => e.IdWishlist)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("ID_Wishlist");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_tb_Wishlist_tb_Products");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Wishlist_tb_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
