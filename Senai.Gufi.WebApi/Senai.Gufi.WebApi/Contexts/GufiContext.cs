using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Gufi.WebApi.Domains
{
    public partial class GufiContext : DbContext
    {
        public GufiContext()
        {
        }

        public GufiContext(DbContextOptions<GufiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Instituicao> Instituicao { get; set; }
        public virtual DbSet<Presencas> Presencas { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DEV10\\SQLEXPRESS; Initial Catalog=Gufi_Manha; user Id=sa; pwd=sa@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Eventos>(entity =>
            {
                entity.HasKey(e => e.IdEvento);

                entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");

                entity.Property(e => e.AcessoLivre)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdInstituicao).HasColumnName("ID_Instituicao");

                entity.Property(e => e.IdTipoEvento).HasColumnName("ID_TipoEvento");

                entity.Property(e => e.NomeEvento)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInstituicaoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdInstituicao)
                    .HasConstraintName("FK__Eventos__ID_Inst__59063A47");

                entity.HasOne(d => d.IdTipoEventoNavigation)
                    .WithMany(p => p.Eventos)
                    .HasForeignKey(d => d.IdTipoEvento)
                    .HasConstraintName("FK__Eventos__ID_Tipo__59FA5E80");
            });

            modelBuilder.Entity<Instituicao>(entity =>
            {
                entity.HasKey(e => e.IdInstituicao);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Institui__AA57D6B49BB2AC07")
                    .IsUnique();

                entity.HasIndex(e => e.Endereco)
                    .HasName("UQ__Institui__4DF3E1FFCD7BB322")
                    .IsUnique();

                entity.HasIndex(e => e.NomeFantasia)
                    .HasName("UQ__Institui__F5389F313CD9F14A")
                    .IsUnique();

                entity.Property(e => e.IdInstituicao).HasColumnName("ID_Instituicao");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Presencas>(entity =>
            {
                entity.HasKey(e => e.IdPresenca);

                entity.Property(e => e.IdPresenca).HasColumnName("ID_Presenca");

                entity.Property(e => e.IdEvento).HasColumnName("ID_Evento");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdEvento)
                    .HasConstraintName("FK__Presencas__ID_Ev__5DCAEF64");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Presencas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Presencas__ID_Us__5CD6CB2B");
            });

            modelBuilder.Entity<TipoEvento>(entity =>
            {
                entity.HasKey(e => e.IdTipoEvento);

                entity.HasIndex(e => e.TipoEvento1)
                    .HasName("UQ__TipoEven__3D13D7E59FF631E2")
                    .IsUnique();

                entity.Property(e => e.IdTipoEvento).HasColumnName("ID_TipoEvento");

                entity.Property(e => e.TipoEvento1)
                    .IsRequired()
                    .HasColumnName("TipoEvento")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.HasIndex(e => e.TipoUsuario1)
                    .HasName("UQ__TipoUsua__52F7E3AA1E9EE80B")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .IsRequired()
                    .HasColumnName("TipoUsuario")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534E278650A")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__ID_Tip__5535A963");
            });
        }
    }
}
