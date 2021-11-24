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
    public class UniteOfWork : IUniteOfWork
    {
        DbContext Context;
        IMainRepo<User> UserRepo;
        IMainRepo<Token> TokenRepo;
        public UniteOfWork (IContextFactory factory,
            IMainRepo<User> userRepo, IMainRepo<Token> tokeRepo)
        {
            Context = factory.GetContext();
            UserRepo = userRepo;
            TokenRepo = tokeRepo;
        }

        public IMainRepo<User> GetUserRepo()
        {
            return UserRepo;
        }
        public IMainRepo<Token> GetTokenRepo()
        {
            return TokenRepo;
        }

        public void save()
        {
            Context.SaveChanges();
        }
    }
}
