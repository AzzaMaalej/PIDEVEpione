using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Threading.Tasks;
using Data;
using Service.Analytics;

namespace GUI
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceDashboard2 sd = new ServiceDashboard2();
            foreach (var item in sd.getAllPatientsNotTreatedByDoctor("83521291-6853-4672-ad39-2f58ae07244a"))
            {
                Console.WriteLine(item.FirstName);
            }


            Console.ReadKey();
        }
    }
}
