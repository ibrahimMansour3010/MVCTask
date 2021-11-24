using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MainRepo<T> : IMainRepo<T> where T: BaseModel
    {
        DbContext Context;
        DbSet<T> Table;
        public MainRepo(IContextFactory _Context)
        {
            Context = _Context.GetContext();
            Table = Context.Set<T>();
        }

        public void Add(T Row)
        {
            Table.Add(Row);
        }
        public void Edit(T Row)
        {
            Context.Entry(Row).State = EntityState.Modified;
        }
        public void Delete(T Row)
        {
            Context.Entry(Row).State = EntityState.Deleted;
        }
        public T GetById(int id)
        {
            return Table.FirstOrDefault(i => i.ID == id);
        }
        public IQueryable<T> GetAll()
        {
            return Table;
        }
    }
}
