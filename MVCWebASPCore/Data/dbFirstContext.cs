using System;
using System.Collections.Generic;
using MVCWebASPCore.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace MVCWebASPCore.Data;

public partial class dbFirstContext : DbContext
{
    public dbFirstContext()
    {
    }

    public dbFirstContext(DbContextOptions<dbFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbClient> TbClients { get; set; }

    public virtual DbSet<TbDetailInvoce> TbDetailInvoces { get; set; }

    public virtual DbSet<TbInvoce> TbInvoces { get; set; }

    public virtual DbSet<TbProduct> TbProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Clien__3214EC0718482CAE");

            entity.ToTable("Tb_Client");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbDetailInvoce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tb_Detai__3214EC07DD6F1FC9");

            entity.ToTable("Tb_DetailInvoce");

            entity.Property(e => e.IdInvoce).HasColumnName("Id_Invoce");
            entity.Property(e => e.IdProduct).HasColumnName("Id_Product");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdInvoceNavigation).WithMany(p => p.TbDetailInvoces)
                .HasForeignKey(d => d.IdInvoce)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Invoce");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.TbDetailInvoces)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detail_Product");
        });

        modelBuilder.Entity<TbInvoce>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tb_invoce");

            entity.ToTable("Tb_Invoce");

            entity.Property(e => e.IdClient).HasColumnName("Id_Client");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.TbInvoces)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_Tb_Invoce_Tb_Cliente");
        });

        modelBuilder.Entity<TbProduct>(entity =>
        {
            entity.ToTable("Tb_Product");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
