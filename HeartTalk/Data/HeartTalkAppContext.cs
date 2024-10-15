using HeartTalk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeartTalk.Data
{

    public class HeartTalkAppContext : DbContext
    {
        public HeartTalkAppContext(DbContextOptions<HeartTalkAppContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasMany(n => n.Comments).WithOne(c => c.Note).HasForeignKey(c => c.NoteId);



        }


    };
}
