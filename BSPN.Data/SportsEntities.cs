using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPN.Data
{
    public partial class SportsEntities : DbContext, IDbContext
    {
        private readonly Guid _contextId = Guid.NewGuid();

        public Guid ContextId
        {
            get
            {
                return this._contextId;
            }
        }

        public void Rollback()
        {
            (
                from e in base.ChangeTracker.Entries()
                where e.State != EntityState.Unchanged
                select e).ToList<DbEntityEntry>().ForEach((DbEntityEntry e) => e.CurrentValues.SetValues(e.OriginalValues));
        }
    }
}
