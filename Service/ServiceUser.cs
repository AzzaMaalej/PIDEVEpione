using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Service
{
    public class ServiceUser : Service<User>, IServiceUser
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ServiceUser(IUnitOfWork utwk) : base(utwk)
        {
        }

        public bool checkUserByRole(User us)
        {
            return false;
        }

        public void addRoleToUser(User u)
        {
        }

    }
}
