using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringService.Alerts
{
    interface UserAlert
    {
        void SendAlert(string message);
        void RegisterForAlerts(string userIdentifier, AlertLevel level);
    }
}
