using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RapidPay.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.API.Data.Database
{
    public class DataContext : IdentityDbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        public virtual DbSet<IdentityUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Cards");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Holder)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Balance);

                entity.HasOne(e => e.User)
                   .WithMany()
                   .HasForeignKey(e => e.UserId);

            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.CardId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Amount)
                    .IsRequired();

                entity.Property(e => e.Fee)
                    .IsRequired();

                entity.Property(e => e.TotalAmount)
                    .IsRequired();

                entity.HasOne(e => e.Card)
                   .WithMany()
                   .HasForeignKey(e => e.CardId);

            });
        }
    }
}
