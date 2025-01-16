using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace MonitoringService.Metrics
{
    public class MetricsService : IMetricsService
    {
        private Queue<Metric> metricsQueue = new Queue<Metric>();
        private int msBetweenProcessing = 1000;
        private int batchSize = 10;

        public void AddMetric(string endpointUrl, long responseTime)
        {
            Metric metric = new(endpointUrl, responseTime, MetricType.ResponseTime);
            metricsQueue.Enqueue(metric);
            // TODO: Add a method of extracting metrics
        }
    
        private void StartMetricQueueIngestion()
        {
            while (true)
            {


                Thread.Sleep(msBetweenProcessing);
            }
        }
    }
}
