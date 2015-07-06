using System.Data.Entity;
using MvcRefactor.Entity;

namespace MvcRefactor.Data
{
    public class MvcBasContext : DbContext
    {
        static MvcBasContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MvcBasContext>());
        }
        public MvcBasContext() : base("StringConnDb") { }
        public DbSet<User> Users { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerRating> PlayerRatings { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Uniform> Uniforms { get; set; }
    }
}