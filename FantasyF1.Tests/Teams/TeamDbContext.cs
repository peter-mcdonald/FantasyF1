using System.Data.Common;
using System.Data.Entity;

namespace FantasyF1.Tests.Teams
{
    class TeamDbContext : DbContext
    {
        public TeamDbContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
