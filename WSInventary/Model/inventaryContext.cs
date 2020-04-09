using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WSInventary.Model
{
    public partial class inventaryContext : DbContext
    {
        public inventaryContext()
        {
        }

        public inventaryContext(DbContextOptions<inventaryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=R1ick2503-.-.;database=inventary", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasComment("tabla de los usuarios del sistema.");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletName)
                    .IsRequired()
                    .HasColumnName("completName")
                    .HasColumnType("varchar(350)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.IdProfile).HasColumnName("idProfile");

                entity.Property(e => e.IdStatus).HasColumnName("idStatus");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(500)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");

                entity.Property(e => e.RegisterDate)
                    .HasColumnName("registerDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasColumnType("varchar(25)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_spanish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
