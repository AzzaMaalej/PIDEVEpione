using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IServicesUser : IService<User>
    {
        IEnumerable<User> getAll();
        User getOne(string id);
    }

}
