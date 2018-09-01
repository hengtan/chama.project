using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Chama.RabitMQ.Consumer
{
    public class Receive
    {
        private static void SimpleConsumerQueue()
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

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, routingkey) =>
                    {
                        var body = routingkey.Body;
                        var message = Encoding.UTF8.GetString(body);

                        //Console.WriteLine("[x] Received message: {0}", message);
                    };

                    channel.BasicConsume(queue: "Enroll",
                        autoAck: true,
                        consumer: consumer);

                    //Console.WriteLine("Press [enter] to exit.");
                    //Console.ReadLine();
                }
            }
        }
    }
}
