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
    };
}
