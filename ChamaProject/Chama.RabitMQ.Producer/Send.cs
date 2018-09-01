using RabbitMQ.Client;
using System.Text;

namespace Chama.RabitMQ.Producer
{
    public class Send
    {
        private static void SimpleQueueSend()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "Enroll",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var totalMensagens = 0;
                    for (totalMensagens = 0; totalMensagens < 5; totalMensagens++)
                    {
                        string message = string.Format("Send to the queue [Enroll]: {0}", totalMensagens);
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                            routingKey: "hello",
                            basicProperties: null,
                            body: body);
                    }
                }
            }
        }
    }
}
