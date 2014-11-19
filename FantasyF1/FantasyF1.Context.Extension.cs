using System.Data.Entity;
using System.Data.EntityClient;

namespace FantasyF1
{
    public partial class FantasyF1Entities : DbContext
    {
        public FantasyF1Entities(EntityConnection connection)
            : base(connection, true)
        {
        }
    }
}