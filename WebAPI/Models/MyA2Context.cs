using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebAPI.Models;

namespace AppDbContext
{
    public partial class MyA2Context : DbContext
    {
        public MyA2Context()
        {
        }

        public MyA2Context(DbContextOptions<MyA2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cotizacione> Cotizaciones { get; set; } = null!;
        public virtual DbSet<Proveedore> Proveedores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=172.0.0.15;Initial Catalog=MyA2;User=joaquin;password=joaquin1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotizacione>(entity =>
            {
                entity.HasIndex(e => e.EntidadId, "IX_Cotizaciones_EntidadId");

                entity.HasIndex(e => e.EspecialidadId, "IX_Cotizaciones_EspecialidadId");

                entity.HasIndex(e => e.FormaDePagoId, "IX_Cotizaciones_FormaDePagoId");

                entity.HasIndex(e => e.LugarId, "IX_Cotizaciones_LugarId");

                entity.HasIndex(e => e.MantenimientoId, "IX_Cotizaciones_MantenimientoId");

                entity.HasIndex(e => e.SituacionDeIvaId, "IX_Cotizaciones_SituacionDeIvaId");

                entity.HasIndex(e => e.SucursalId, "IX_Cotizaciones_SucursalId");

                entity.HasIndex(e => e.TasaDeIvaid, "IX_Cotizaciones_TasaDeIVAId");

                entity.HasIndex(e => e.TipoOperacionId, "IX_Cotizaciones_TipoOperacionId");

                entity.HasIndex(e => e.ZonaId, "IX_Cotizaciones_ZonaId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Auxiliar).HasColumnName("auxiliar");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Metodo)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TasaDeIvaid).HasColumnName("TasaDeIVAId");
            });

            modelBuilder.Entity<Proveedore>(entity =>
            {
                entity.HasIndex(e => e.DepartamentoId, "IX_Proveedores_DepartamentoId");

                entity.HasIndex(e => e.LocalidadId, "IX_Proveedores_LocalidadId");

                entity.HasIndex(e => e.ProvinciaId, "IX_Proveedores_ProvinciaId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodPostal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Contacto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuit)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gln)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tel1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
