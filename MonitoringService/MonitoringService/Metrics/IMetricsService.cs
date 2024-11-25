namespace MonitoringService.Metrics
{
    public interface IMetricsService
    {
        void AddResponseTimeMetric(string endpointUrl, long responseTime);
    }
}