using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoDesarrollo.B.P.Models;

public partial class VentasC : DbContext
{
    public VentasC()
    {
    }

    public VentasC(DbContextOptions<VentasC> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategoria> TbCategoria { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetalleVenta> TbDetalleventa { get; set; }

    public virtual DbSet<TbProducto> TbProductos { get; set; }

    public virtual DbSet<TbVenta> TbVenta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Data Source=ALDO-ALEGRIA-ME;Initial Catalog=VentasProdMascotas;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.HasKey(e => e.CodCategoria).HasName("PK__TB_CATEG__5A4D9907AC91AB07");

            entity.ToTable("TB_CATEGORIA");

            entity.Property(e => e.CodCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CATEGORIA");
            entity.Property(e => e.NomCat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CAT");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.CodCliente).HasName("PK__TB_CLIEN__8112345F3271B781");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.CodCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CLIENTE");
            entity.Property(e => e.ApeCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("APE_CLI");
            entity.Property(e => e.DirCli)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIR_CLI");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.NomCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOM_CLI");
        });

        modelBuilder.Entity<TbDetalleVenta>(entity =>
        {
            entity.HasKey(e => new { e.CodVenta, e.CodProducto }).HasName("PK__TB_DETAL__77752C1EDD846E75");

            entity.ToTable("TB_DETALLEVENTA");

            entity.Property(e => e.CodVenta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_VENTA");
            entity.Property(e => e.CodProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_PRODUCTO");
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodProductoNavigation).WithMany(p => p.TbDetalleventa)
                .HasForeignKey(d => d.CodProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__COD_P__5441852A");

            entity.HasOne(d => d.CodVentaNavigation).WithMany(p => p.TbDetalleventa)
                .HasForeignKey(d => d.CodVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_DETALL__COD_V__534D60F1");
        });

        modelBuilder.Entity<TbProducto>(entity =>
        {
            entity.HasKey(e => e.CodProducto).HasName("PK__TB_PRODU__8DF7FD2D50958E6A");

            entity.ToTable("TB_PRODUCTO");

            entity.Property(e => e.CodProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_PRODUCTO");
            entity.Property(e => e.CodCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CATEGORIA");
            entity.Property(e => e.EstaProducto)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTA_PRODUCTO");
            entity.Property(e => e.NomProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOM_PRODUCTO");
            entity.Property(e => e.PreProducto)
                .HasColumnType("money")
                .HasColumnName("PRE_PRODUCTO");
            entity.Property(e => e.StkProducto).HasColumnName("STK_PRODUCTO");

            entity.HasOne(d => d.CodCategoriaNavigation).WithMany(p => p.TbProductos)
                .HasForeignKey(d => d.CodCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_PRODUC__COD_C__5070F446");
        });

        modelBuilder.Entity<TbVenta>(entity =>
        {
            entity.HasKey(e => e.CodVenta).HasName("PK__TB_VENTA__BFAA53CC3E378D60");

            entity.ToTable("TB_VENTA");

            entity.Property(e => e.CodVenta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_VENTA");
            entity.Property(e => e.CodCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("COD_CLIENTE");
            entity.Property(e => e.EstadoVenta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ESTADO_VENTA");
            entity.Property(e => e.FecVenta)
                .HasColumnType("date")
                .HasColumnName("FEC_VENTA");
            entity.Property(e => e.TotalVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("TOTAL_VENTA");

            entity.HasOne(d => d.CodClienteNavigation).WithMany(p => p.TbVenta)
                .HasForeignKey(d => d.CodCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TB_VENTA__COD_CL__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
