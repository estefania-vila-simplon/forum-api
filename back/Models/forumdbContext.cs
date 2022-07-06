using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace back.Models
{
    public partial class forumdbContext : DbContext
    {
        public forumdbContext()
        {
        }

        public forumdbContext(DbContextOptions<forumdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=forum-db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.CommentId)
                    .ValueGeneratedNever()
                    .HasColumnName("CommentID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifDate).HasColumnType("datetime");

                entity.HasOne(d => d.CommentTopic)
                    .WithOne(p => p.TopicComment)
                    .HasForeignKey<Comment>(d => d.CommentId)
                    .HasConstraintName("CommentTopic_TopicID");

                entity.HasOne(d => d.CommentUser)
                    .WithOne(p => p.Comment)
                    .HasForeignKey<Comment>(d => d.CommentId)
                    .HasConstraintName("CommentUser_UserID");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.TopicId)
                    .ValueGeneratedNever()
                    .HasColumnName("TopicID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifDate).HasColumnType("datetime");

                entity.Property(e => e.TopicTitle).HasMaxLength(50);

                entity.HasOne(d => d.TopicUser)
                    .WithOne(p => p.Topic)
                    .HasForeignKey<Topic>(d => d.TopicId)
                    .HasConstraintName("TopicUser_UserID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.UserEmail).HasMaxLength(50);

                entity.Property(e => e.UserLastName).HasMaxLength(45);

                entity.Property(e => e.UserName).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
