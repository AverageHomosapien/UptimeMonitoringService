﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringService.Alerts
{
    public class SMSAlerts : UserAlert
    {
        public void SendAlert(string message)
        {
            throw new NotImplementedException();
        }

        void UserAlert.RegisterForAlerts(string userIdentifier, AlertLevel level)
        {
            throw new NotImplementedException();
        }
    }
}
