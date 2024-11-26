namespace MonitoringService.Metrics
{
    public interface IMetricsService
    {
        void AddMetric(string endpointUrl, long responseTime);
    }
}