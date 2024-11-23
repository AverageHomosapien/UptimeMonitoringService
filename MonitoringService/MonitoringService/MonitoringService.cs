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
    public class MonitoringService
    {
        private ILog log = LogManager.GetLogger(typeof(MonitoringService));
        private HttpClient client = new HttpClient();
        private Timer? backgroundTimer;
        private Stopwatch sw = new Stopwatch();
        private MetricsService metricsService = new MetricsService();

        private int pollingInterval = 200;
        // This is just one endpoint, but you can add more endpoints to monitor
        private string endpoint = "/health_check";
        private string siteUrl = "http://localhost:3000";

        public void Start()
        {
            StartPolling();
        }

        private void StartPolling()
        {
            // Initialise a timer to poll every *pollingInterval* milliseconds
            backgroundTimer = new Timer(Poll, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(pollingInterval));
            log.Info("Polling service started");
        }

        /// <summary>
        /// Poll the endpoint and add the response time to the metrics queue
        /// </summary>
        /// <param name="state"></param>
        private async void Poll(object? state)
        {
            try
            {
                Uri monitoredUri = new(siteUrl + endpoint);
                sw.Restart(); 
                await client.GetAsync(monitoredUri);
                long responseTime = sw.ElapsedMilliseconds;
                metricsService.AddResponseTimeMetric(endpoint, responseTime);
            }
            catch (Exception ex)
            {
                log.Error("Unable to access the endpoint...", ex);
            }
        }
    }
}
