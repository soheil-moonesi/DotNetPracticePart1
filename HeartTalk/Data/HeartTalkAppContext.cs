using HeartTalk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HeartTalk.Data
{
    public class HeartTalkAppContext : DbContext
    { 
        public DbSet<Note> Notes { get; set; }
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = HeartTalkDb; Integrated Security = True; TrustServerCertificate = True");
     }
    }
}
