using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MonitoringService.Metrics;

namespace MonitoringService
{
    public class MonitoringService : IMonitoringService
    {
        private readonly ILog log = LogManager.GetLogger(typeof(MonitoringService));
        private readonly HttpClient client = new HttpClient();
        private readonly Stopwatch sw = new Stopwatch();
        private readonly IMetricsService metricsService;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private int pollingInterval = 500;
        // This is just one endpoint, but you can add more endpoints to monitor
        private const string endpoint = "/health_check";
        private const string siteUrl = "http://localhost:3000";

        public MonitoringService(IMetricsService metricsService)
        {
            this.metricsService = metricsService;
            cancellationTokenSource.CancelAfter(5000);
        }

        public async Task Start()
        {
            await StartPolling();
        }

        /// <summary>
        /// Poll the endpoint and add the response time to the metrics queue
        /// </summary>
        /// <param name="state"></param>
        private async Task StartPolling()
        {
            log.Info("Polling service started");
            while (true)
            {
                Thread.Sleep(pollingInterval);
                try
                {
                    Uri monitoredUri = new(siteUrl + endpoint);
                    sw.Restart();
                    await client.GetAsync(monitoredUri, cancellationTokenSource.Token);
                    long responseTime = sw.ElapsedMilliseconds;
                    metricsService.AddMetric(endpoint, responseTime);
                }
                catch (Exception ex)
                {
                    log.Error("Unable to access the endpoint...", ex);
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
