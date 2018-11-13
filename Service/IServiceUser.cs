using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IServiceUser : IService<User>
    {
        bool checkUserByRole(User us);
    }
}
