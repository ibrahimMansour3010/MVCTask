using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IMainRepo<T>
    {
        void Add(T Row);
        void Edit(T Row);
        void Delete(T Row);
        T GetById(int id);
        IQueryable<T> GetAll();
    }
}
