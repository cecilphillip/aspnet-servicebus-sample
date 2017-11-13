using System.Threading.Tasks;
using SimpleWebAppointment.Models;
using Microsoft.Extensions.Options;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace SimpleWebAppointment.Services
{
    public class AppointmentService
    {
        private readonly QueueClient _queueClient;

        public AppointmentService(IOptions<ServicebusConfig> servicebusConfig)
        {
            this._queueClient = new QueueClient(servicebusConfig.Value.ConnectionString, servicebusConfig.Value.QueueName);
        }

        public async Task SubmitForProcessing(AppointmentRequest appointmentRequest)
        {
            string messageContent = JsonConvert.SerializeObject(appointmentRequest);
            Message message = new Message(Encoding.UTF8.GetBytes(messageContent));
            await _queueClient.SendAsync(message);
        }
    }
}
