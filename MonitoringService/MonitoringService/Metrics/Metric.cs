﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringService.Metrics
{
    public record Metric(string Name, long Value, MetricType Type);
}
