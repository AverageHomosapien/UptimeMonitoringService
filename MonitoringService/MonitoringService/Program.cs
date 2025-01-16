using MonitoringService;

DependencyRegistration dependencyRegistration = new DependencyRegistration();
dependencyRegistration.RegisterDependencies();

IMonitoringService monitoringService = dependencyRegistration.DependencyManager.GetService<IMonitoringService>();
await monitoringService.Start();
