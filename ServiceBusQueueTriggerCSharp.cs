using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using System.Text;

namespace Company.Function
{
    public static class ServiceBusQueueTriggerCSharp
    {
        [FunctionName("ServiceBusQueueTriggerCSharp")]
        public static void Run([ServiceBusTrigger("widgets", Connection = "csefeedback-sb-session_SERVICEBUS", IsSessionsEnabled = true)] Message[] items, ILogger log)
        {
            log.LogInformation($"Received {items.Length} messages.");

            foreach (Message msg in items)
            {
                // Process the message
                Console.WriteLine($"Received message: SessionId: {msg.SessionId} SequenceNumber:{msg.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(msg.Body)}");

            }
        }
    }
}
