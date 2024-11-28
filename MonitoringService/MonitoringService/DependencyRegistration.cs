using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightweight.Dependency.Injection;
using log4net;
using log4net.Config;
using MonitoringService.Metrics;

namespace MonitoringService
{
    public class DependencyRegistration
    {
        private ILog log = LogManager.GetLogger(typeof(DependencyRegistration));
        public DependencyManager DependencyManager { get; private set; } = new DependencyManager();

        public void RegisterDependencies()
        {
            InitialiseLogging();

            DependencyManager.AddSingleton<IMetricsService, MetricsService>();
            DependencyManager.AddSingleton<IMonitoringService, MonitoringService>();
            DependencyManager.Build();

            log.Info("Finished registering dependencies");
        }

        private void InitialiseLogging()
        {
            var log4netConfig = new FileInfo("log4net.config");
            XmlConfigurator.Configure(log4netConfig);
        }
    }
}
