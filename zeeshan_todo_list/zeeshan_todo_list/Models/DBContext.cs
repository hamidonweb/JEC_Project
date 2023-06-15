using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace zeeshan_todo_list.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategory> TbCategories { get; set; } = null!;
        public virtual DbSet<TbTodo> TbTodos { get; set; } = null!;
        public virtual DbSet<TbUser> TbUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HDF2VCS\\ZEESHAN; Database=mytodos_DB; Trusted_Connection=True; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.ToTable("tb_Categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasMaxLength(250);
            });

            modelBuilder.Entity<TbTodo>(entity =>
            {
                entity.ToTable("tb_todos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Sequence).HasColumnName("sequence");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TodoDesc)
                    .HasMaxLength(250)
                    .HasColumnName("Todo_desc");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.ToTable("tb_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(150)
                    .HasColumnName("user_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
