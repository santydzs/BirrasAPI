using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Entity
{
    public partial class BirrasContext : DbContext
    {
        public BirrasContext()
        {
        }

        public BirrasContext(DbContextOptions<BirrasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<Meet> Meets { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("Invitation");

                entity.Property(e => e.Attended).HasColumnName("attended");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.MeetId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invitations)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Meet>(entity =>
            {
                entity.ToTable("Meet");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.HasOne(d => d.Meet)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.MeetId);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
