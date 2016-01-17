using DWDataService;
using System;
using System.Data.Services;
using System.ServiceProcess;


namespace DWService
{
    public partial class Service : ServiceBase
    {
        private ProjectInstaller projectInstaller2;


        public Service()
        {
            this.AutoLog = true;
            this.CanPauseAndContinue = true;
            this.CanStop = true;
            this.ServiceName = "DatamineToWencoService";
            InitializeComponent();
        }

        //private void InitializeComponent()
        //{
        //    //log4net.Config.XmlConfigurator.Configure();
        //    this.projectInstaller2 = new ProjectInstaller();
        //}

        public void StartServ(string[] args)
        {
            this.OnStart(args);
        }

        public void StopServ()
        {
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            Type ServiceType = typeof(DatamineDataService);
            Uri baseAddress = new Uri("http://localhost:6000");
            Uri[] baseAddresses = new Uri[] { baseAddress };
            DataServiceHost host = new DataServiceHost(ServiceType,baseAddresses);
            host.Open();
            


            //log.Info("Запустили сервис");
            //logCon.Info("Запустили сервис");

        }

        protected override void OnStop()
        {
            //log.Info("Останавливаем сервис");
            //logCon.Info("Останавливаем сервис");

        }
    }
}
