using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lightweight.Dependency.Injection;
using MonitoringService.Metrics;

namespace MonitoringService
{
    public class DependencyRegistration
    {
        public DependencyManager DependencyManager { get; private set; } = new DependencyManager();

        public void RegisterDependencies()
        {
            DependencyManager.AddSingleton<IMetricsService, MetricsService>();
            DependencyManager.AddSingleton<IMonitoringService, MonitoringService>();
            DependencyManager.Build();
        }
    }
}
