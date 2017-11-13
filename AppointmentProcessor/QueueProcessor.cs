using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;

namespace AppointmentProcessor
{
    public static class QueueProcessor
    {
        [FunctionName("ProcessNewRequests")]
        public static void ProcessNewRequests([ServiceBusTrigger("appointments-queue", AccessRights.Listen, Connection = "ServicebusConnection")]string queueItem, TraceWriter log)
        {
            AppointmentRequest request = JsonConvert.DeserializeObject<AppointmentRequest>(queueItem);

            log.Info($"New appointment request was made by {request.Name}");

            //Sweet sweet scheduling logic go here !
        }

        [FunctionName("HandleDeadLetterQueue")]
        public static void HandleDeadLetterQueue([ServiceBusTrigger("appointments-queue/$DeadLetterQueue", AccessRights.Listen, Connection = "ServicebusConnection")]string queueItem, TraceWriter log)
        {
            AppointmentRequest request = JsonConvert.DeserializeObject<AppointmentRequest>(queueItem);

            log.Warning("Retrieved message from the dead-letter queue");         
        }
    }
}
