using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EspacePatient
{
    public class ServiceProfil_Patient:Service<Patient>,IServiceProfil_Patient
    {
        static IDatabaseFactory dbf = new DatabaseFactory();
        
        static IUnitOfWork uof = new UnitOfWork(dbf);

        public ServiceProfil_Patient():base(uof)
        {

        }
    }
}
