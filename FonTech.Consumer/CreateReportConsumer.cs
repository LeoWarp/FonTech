using System.Diagnostics;
using System.Text;
using FonTech.Domain.EventModels;
using FonTech.Domain.Settings;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FonTech.Consumer;

/*public class RabbitMqListener : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IOptions<RabbitMqSettings> _options;

    public RabbitMqListener(IOptions<RabbitMqSettings> options)
    {
        _options = options;
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _options.Value.QueueName = "dead_queue";
        _channel.QueueDeclare(_options.Value.QueueName, durable: true, exclusive: false, autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (obj, basicDeliver) =>
        {
            var content = Encoding.UTF8.GetString(basicDeliver.Body.ToArray());
            Debug.WriteLine($"Получено сообщение: {content}");
            
            _channel.BasicAck(basicDeliver.DeliveryTag, false);
        };
        _channel.BasicConsume(_options.Value.QueueName, false, consumer);
        
        return Task.CompletedTask;
    }
}*/

public class CreateReportConsumer : IConsumer<CreateReportEvent>
{
    private readonly ILogger<CreateReportConsumer> _logger;

    public CreateReportConsumer(ILogger<CreateReportConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<CreateReportEvent> context)
    {
        var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"ReportCreated message: {jsonMessage}");

        return Task.CompletedTask;
    }
}