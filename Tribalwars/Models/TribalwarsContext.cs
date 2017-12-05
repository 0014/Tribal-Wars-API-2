using System.Data.Entity;

namespace Tribalwars.Models
{
    public class TrivalwarsContext : DbContext
    {
        public DbSet<FarmVillages> FarmVillages { get; set; }

        public DbSet<FarmAttacks> FarmAttacks { get; set; }

        public TrivalwarsContext()
        {
            
        }
    }
}
