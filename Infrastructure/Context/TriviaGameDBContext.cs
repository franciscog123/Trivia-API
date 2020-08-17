using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Infrastructure.Entities;

namespace Infrastructure.Context
{
    public partial class TriviaGameDBContext : DbContext
    {
        public TriviaGameDBContext()
        {
        }

        public TriviaGameDBContext(DbContextOptions<TriviaGameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Choice> Choice { get; set; }
        public virtual DbSet<GameMode> GameMode { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestion { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TRIVIADB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Category1)
                    .IsRequired()
                    .HasColumnName("Category")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Choice>(entity =>
            {
                entity.Property(e => e.Choice1)
                    .IsRequired()
                    .HasColumnName("Choice")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Choice)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuestionId_Choice_Question");
            });

            modelBuilder.Entity<GameMode>(entity =>
            {
                entity.Property(e => e.GameMode1)
                    .IsRequired()
                    .HasColumnName("GameMode")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("Question")
                    .HasMaxLength(300);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CategoryId_Question_Category");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.GameMode)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.GameModeId)
                    .HasConstraintName("FK_GameModeId_Quiz_GameMode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quiz)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId_Quiz_User");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_QuestionId_QuizQuestion_Question");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestion)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizId_QuizQuestion_Quiz");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
