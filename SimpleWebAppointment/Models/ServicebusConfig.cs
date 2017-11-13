using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebAppointment.Models
{
    public class ServicebusConfig
    {
        public string QueueName { get; set; }
        public string ConnectionString { get; set; }
    }
}
