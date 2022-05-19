using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APISenaiSCS.Domains;

#nullable disable

namespace APISenaiSCS.Contexts
{
    public partial class APISnaiSCSContext : DbContext
    {
        public APISnaiSCSContext()
        {
        }

        public APISnaiSCSContext(DbContextOptions<APISnaiSCSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<campanha> campanhas { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = NOTE0113A3\\SQLEXPRESS; Initial Catalog = GerenciamentoCampanha; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<campanha>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("campanha");

                entity.Property(e => e.id).ValueGeneratedOnAdd();

                entity.Property(e => e.imagem)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuario");

                entity.Property(e => e.NIF)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.id).ValueGeneratedOnAdd();

                entity.Property(e => e.senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
