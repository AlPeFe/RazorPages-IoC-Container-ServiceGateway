using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.Models
{
    public partial class gamdroidContext : DbContext
    {
        public gamdroidContext()
        {
        }

        public gamdroidContext(DbContextOptions<gamdroidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<Vhi> Vhi { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=82.223.10.68;Initial Catalog=gamdroid;User ID=gamxxi;Password=psoft;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HostUrl)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdateDate).HasColumnType("date");

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.GamId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdActionNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdAction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Action");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_State");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Type");

                entity.HasOne(d => d.VhiNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.Vhi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_Vhi1");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vhi>(entity =>
            {
                entity.Property(e => e.CodigoVhi)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ContextId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
