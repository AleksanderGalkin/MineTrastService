using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DWService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Service serv = new Service();
            if (Environment.UserInteractive)
            {
                serv.StartServ(args);
                Console.WriteLine("Press Enter key to stop program");
                Console.Read();
                serv.StopServ();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new Service()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}




