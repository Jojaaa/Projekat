using Microsoft.EntityFrameworkCore;

namespace WebProj.Models {

    public class KoktelBarContext : DbContext
    {
        public DbSet<KoktelBar> KBarovi {get; set;}

        public DbSet<Sto> Stolovi {get; set;}

        public DbSet<Porudzbina> Porudzbine {get; set;}

        public KoktelBarContext(DbContextOptions options):base(options)
        {
            
        }

    }
}