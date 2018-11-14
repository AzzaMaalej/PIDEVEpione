﻿using Data.Infrastructure;
using Domain;
using Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Analytics
{
    public class ServiceDashboard2 : Service<Patient>, IServiceDashboard2
    {
        static IDatabaseFactory dbf = new DatabaseFactory();

        static IUnitOfWork uow = new UnitOfWork(dbf);

        public ServiceDashboard2() : base(uow)
        {
        }

        public IEnumerable<Patient> getAllPatients()
        {
            return GetMany();
        }
        public IEnumerable<Patient> getAllPatientsTreated()
        {
            var app = uow.getRepository<Appointment>().GetMany(a => a.AppointmentState == StateEnum.Completed);
            var req = from patients in GetMany()
                      join ap in app
                      on patients.Id equals ap.PatientId
                      select patients;
            return req;
        }
    }
}