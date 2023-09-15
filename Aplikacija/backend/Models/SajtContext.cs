using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class SajtContext : DbContext
    {
        public DbSet<StrucnoLice> StrucnaLIca { get; set; }

        public DbSet<Sajt> Sajt { get; set; }

        public DbSet<Plan> Planovi { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Administrator> Admini { get; set; }

        public DbSet<Obrok> Obroci { get; set; }

        public DbSet<Vezba> Vezbe { get; set; }

        public DbSet<KomentarIOcena> KomentarIOcena {get; set;}

        public DbSet<Poruka> Poruke {get; set;}
        
        public SajtContext(DbContextOptions options) : base(options)
        {

        }
    }
}