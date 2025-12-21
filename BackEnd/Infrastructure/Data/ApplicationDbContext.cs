using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // --- 2. Knowledge Base ---
        public DbSet<PlantInfo> PlantInfos { get; set; }
        public DbSet<PlantGuideStep> PlantGuideSteps { get; set; }

        // --- 3. Farming & Traceability ---
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<CropActivityLog> CropActivityLogs { get; set; }

        // --- 4. Auctions ---
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }

        // --- 5. Orders (Direct Sale) ---
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // --- 6. Reviews ---
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles", "security");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "security");
            // === 1. ضبط التعامل مع الأموال (Decimal Precision) ===
            // SQL Server يحتاج تحديد الدقة للأرقام العشرية لتجنب الأخطاء
            modelBuilder.Entity<Auction>()
                .Property(a => a.StartPrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Auction>()
                .Property(a => a.CurrentHighestBid).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Bid>()
                .Property(b => b.Amount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Crop>()
                .Property(c => c.DirectSalePrice).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");


            // === 2. ضبط العلاقات المعقدة (Relationships) ===

            // علاقة التقييمات (Reviews)
            // المستخدم يمكن أن يكون "مُقَيِّم" (Reviewer) أو "مُقَيَّم" (Target)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany() // المستخدم الواحد كتب تقييمات كتير
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); // ممنوع حذف المستخدم إذا كان له تقييمات كتبها (لحفظ التاريخ)

            modelBuilder.Entity<Review>()
                .HasOne(r => r.TargetUser)
                .WithMany() // المستخدم الواحد استقبل تقييمات كتير
                .HasForeignKey(r => r.TargetUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة المزايدات (Bids)
            // إذا حذفنا المزاد، تحذف المزايدات (Cascade)
            // لكن إذا حذفنا المستخدم، لا نحذف المزايدات لكي لا يخرب تاريخ المزاد
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Bidder)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة المزارع والمحاصيل
            modelBuilder.Entity<Farm>()
                .HasMany(f => f.Crops)
                .WithOne(c => c.Farm)
                .HasForeignKey(c => c.FarmId)
                .OnDelete(DeleteBehavior.Cascade); // لو المزرعة اتمسحت، المحاصيل تتمسح

            // علاقة الطلبات (Orders)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Buyer)
                .WithMany()
                .HasForeignKey(o => o.BuyerId)
                .OnDelete(DeleteBehavior.Restrict); // لا تحذف الطلب بحذف المستخدم
        }

    }
}