// See https://aka.ms/new-console-template for more information
using MonitoringService;

Console.WriteLine("Hello, World!");

DependencyRegistration dependencyRegistration = new DependencyRegistration();
dependencyRegistration.RegisterDependencies();

IMonitoringService monitoringService = dependencyRegistration.DependencyManager.GetService<IMonitoringService>();
monitoringService.Start();


Thread.Sleep(10000);
Console.WriteLine("Done..");
