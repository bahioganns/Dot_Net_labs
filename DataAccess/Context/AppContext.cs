using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Context
{
    public partial class NotesAppContext : DbContext
    {
        public NotesAppContext()
        {
        }

        public NotesAppContext(DbContextOptions<NotesAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=notes.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasOne(note => note.User)
                      .WithMany(user => user.Notes)
                      .HasForeignKey(note => note.UserId);

                entity.Property(note => note.Title).IsRequired();
                entity.Property(note => note.Content).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(user => user.Email).IsRequired();
                entity.HasIndex(user => user.Email).IsUnique();

                entity.Property(user => user.PasswordHash).IsRequired();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
