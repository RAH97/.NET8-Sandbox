using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace UniversityRankingAPI.Models.Entities
{
    public class UniversityContext : DbContext
    {
        public DbSet<UniversityData> UniversityData { get; set; } = null;
        public DbSet<Location> Location { get; set; } = null;
        public UniversityContext(DbContextOptions<UniversityContext> options): base(options) 
        {
            
        }
    }
}
