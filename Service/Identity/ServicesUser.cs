using Data;
using Data.Infrastructure;
using Domain;
using Microsoft.AspNet.Identity;
using Service;
using Service.Identity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePattern
{
   public class ServicesUser :Service<User>, IServicesUser
    
    {
        //   MyfinanceContex context = new MyfinanceContex();
        public ApplicationUserManager UserManager { get; set; }

        static DatabaseFactory DBF = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);
        public ServicesUser() : base(UOW)
        {
            ApplicationUserStore store = new ApplicationUserStore(new PiContext());
            UserManager = new ApplicationUserManager(store);
        }

        //  IRepositoryBase<Product> RBP = new RepositoryBase<Product>(DBF);



        /*  public Boolean verif(String Log , String pswd)
          {
              Boolean v = true;
              var req = from p in GetMany()
                        where p.Email == Log
                        || p.Password == pswd
                        select p;
              if (req != null)
                  v = false;
              return v;
          }*/

        public IEnumerable<User> getAll()
        {
            return GetMany();
        }

        public User getOne(String id)
        {
            return Get(c => c.Id.Equals(id));
        }

    }
}
