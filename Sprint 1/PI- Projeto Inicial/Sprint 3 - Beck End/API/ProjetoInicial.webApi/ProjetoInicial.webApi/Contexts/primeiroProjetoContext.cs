using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoInicial.webApi.Domains;

#nullable disable

namespace ProjetoInicial.webApi.Contexts
{
    public partial class primeiroProjetoContext : DbContext
    {
        public primeiroProjetoContext()
        {
        }

        public primeiroProjetoContext(DbContextOptions<primeiroProjetoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipamento> Equipamentos { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<SalasEquipamento> SalasEquipamentos { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AJCTALD\\SQLEXPRESS; initial catalog=projetoInicial3T ; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Equipamento>(entity =>
            {
                entity.HasKey(e => e.IdEquipamento)
                    .HasName("PK__equipame__75940D34EA75936F");

                entity.ToTable("equipamentos");

                entity.HasIndex(e => e.NumeroSerie, "UQ__equipame__71472B4D07959210")
                    .IsUnique();

                entity.HasIndex(e => e.NumeroPatrimonio, "UQ__equipame__D46FDABA3EB949CA")
                    .IsUnique();

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.Disponivel).HasColumnName("disponivel");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.NumeroPatrimonio)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("numeroPatrimonio");

                entity.Property(e => e.NumeroSerie)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("numeroSerie");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.IdSala)
                    .HasName("PK__salas__C4AEB19C94F80D89");

                entity.ToTable("salas");

                entity.HasIndex(e => e.Andar, "UQ__salas__BEDE56E1916946A4")
                    .IsUnique();

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.Property(e => e.Andar).HasColumnName("andar");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Metragem).HasColumnName("metragem");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Salas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__salas__idUsuario__4222D4EF");
            });

            modelBuilder.Entity<SalasEquipamento>(entity =>
            {
                entity.HasKey(e => e.IdSalasEquipamento)
                    .HasName("PK__salasEqu__8ADD9F2099FDDB3B");

                entity.ToTable("salasEquipamentos");

                entity.Property(e => e.IdSalasEquipamento).HasColumnName("idSalasEquipamento");

                entity.Property(e => e.IdEquipamento).HasColumnName("idEquipamento");

                entity.Property(e => e.IdSala).HasColumnName("idSala");

                entity.HasOne(d => d.IdEquipamentoNavigation)
                    .WithMany(p => p.SalasEquipamentos)
                    .HasForeignKey(d => d.IdEquipamento)
                    .HasConstraintName("FK__salasEqui__idEqu__45F365D3");

                entity.HasOne(d => d.IdSalaNavigation)
                    .WithMany(p => p.SalasEquipamentos)
                    .HasForeignKey(d => d.IdSala)
                    .HasConstraintName("FK__salasEqui__idSal__44FF419A");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTiposUsuario)
                    .HasName("PK__tiposUsu__E45DC1B57261D936");

                entity.ToTable("tiposUsuario");

                entity.HasIndex(e => e.Nome, "UQ__tiposUsu__6F71C0DCF32E0332")
                    .IsUnique();

                entity.Property(e => e.IdTiposUsuario).HasColumnName("idTiposUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A644AD973A");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E61641979640C")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTiposUsuario).HasColumnName("idTiposUsuario");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTiposUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTiposUsuario)
                    .HasConstraintName("FK__usuario__idTipos__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
