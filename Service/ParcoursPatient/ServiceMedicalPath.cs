using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ParcoursPatient
{
     public class ServiceMedicalPath: Service<MedicalPath>, IServiceMedicalPath
    { // MyfinanctCtx ctx = new MyfinanctCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();
        // IRepositoryBase<Product> repo = new RepositoryBase<Product>(dbf);
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceMedicalPath():base(uow)
        {

        }

        public MedicalPath GetById(object value)
        {
            throw new NotImplementedException();
        }
    }
}
