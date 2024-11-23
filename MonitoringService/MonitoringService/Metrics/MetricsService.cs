using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringService.Metrics
{
    public class MetricsService
    {
        private Queue<Metric> metricsQueue = new Queue<Metric>();

        public void AddResponseTimeMetric(string endpointUrl, long responseTime)
        {
            Metric metric = new Metric(endpointUrl, responseTime, MetricType.PollingInterval);
            metricsQueue.Enqueue(metric);
            // TODO: Add a method of extracting metrics
        }
    }
}
