using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HROADS.webApi.Domains;

#nullable disable

namespace HROADS.webApi.Contexts
{
    public partial class HROADSContext : DbContext
    {
        public HROADSContext()
        {
        }

        public HROADSContext(DbContextOptions<HROADSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LEVIxD\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=LAPTOP-7R4I65FT\\SQLEXPRESS; initial catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=SQLsenha123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classe__60FFF801BD7F1CF3");

                entity.ToTable("Classe");

                entity.Property(e => e.IdClasse)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasse");

                entity.Property(e => e.NomeClasse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeClasse");
            });

            modelBuilder.Entity<ClasseHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClasseHabilidade)
                    .HasName("PK__Classe_H__8F089DDC5192C387");

                entity.ToTable("Classe_Habilidade");

                entity.Property(e => e.IdClasseHabilidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClasse_Habilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHab).HasColumnName("idHab");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Classe_Ha__idCla__403A8C7D");

                entity.HasOne(d => d.IdHabNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdHab)
                    .HasConstraintName("FK__Classe_Ha__idHab__412EB0B6");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHab)
                    .HasName("PK__Habilida__3F4876097B2DC80D");

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHab)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idHab");

                entity.Property(e => e.DescricaoHabilidade)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descricaoHabilidade");

                entity.Property(e => e.IdTipoHab).HasColumnName("idTipoHab");

                entity.Property(e => e.NomeHabilidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeHabilidade");

                entity.HasOne(d => d.IdTipoHabNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHab)
                    .HasConstraintName("FK__Habilidad__idTip__3D5E1FD2");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__E175C72ED7745A5E");

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idPersonagem");

                entity.Property(e => e.DataCriação)
                    .HasColumnType("date")
                    .HasColumnName("dataCriação");

                entity.Property(e => e.DataUpdate)
                    .HasColumnType("date")
                    .HasColumnName("dataUpdate");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.ManaMax).HasColumnName("manaMax");

                entity.Property(e => e.NomePersonagem)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nomePersonagem");

                entity.Property(e => e.VidaMax).HasColumnName("vidaMax");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__idCla__38996AB5");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHab)
                    .HasName("PK__TipoHabi__FD3EC2548279ABC7");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHab)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoHab");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipo");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF297FBA7D");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A64C8948E8");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Senha)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Usuario__idTipo__45F365D3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
