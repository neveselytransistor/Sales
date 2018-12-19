using System;
using Microsoft.EntityFrameworkCore;
using Sales.Models;

namespace Sales
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                        .HasKey(detail => new {detail.OrderID, detail.ProductID});

            modelBuilder.Entity<OrderDetail>()
                        .HasOne(p => p.Order)
                        .WithMany(p => p.OrderDetail)
                        .HasForeignKey(detail => detail.OrderID);

            modelBuilder.Entity<OrderDetail>()
                        .HasOne(p => p.Product)
                        .WithMany(p => p.OrderDetail)
                        .HasForeignKey(detail => detail.ProductID);

            //TODO Убрать при переходе к SQL Server
            var date = DateTime.Now;
            modelBuilder.Entity<Order>().HasData(
                new[]
                {
                    new Order
                    {
                        ID = 1,
                        OrderDate = date
                    }
                });
            modelBuilder.Entity<Product>().HasData(
                new[]
                {
                    new Product
                    {
                        ID = 2,
                        Name = "tea",
                        UnitPrice = 1
                    }
                });
            modelBuilder.Entity<OrderDetail>().HasData(
                new []
                {
                    new OrderDetail
                    {
                        ID = 1,
                        OrderID = 1,
                        ProductID = 2,
                        Quantity = 1
                    }
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}