using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ContextFactory: IContextFactory
    {
        private readonly DbContext Context;
        public ContextFactory()
        {
            Context = Context ?? new MyContext(); // if null 
        }
        public DbContext GetContext()
        {
            return Context;
        }
    }
}
