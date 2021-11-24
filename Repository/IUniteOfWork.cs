using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IUniteOfWork
    {
        IMainRepo<User> GetUserRepo();
        IMainRepo<Token> GetTokenRepo();
        void save();
    }
}
