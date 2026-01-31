using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Logging;
using System.Text;
using Newtonsoft.Json;

namespace Infrastructure.Bus;

public class BaseServiceBus : IAsyncDisposable
{
    private readonly ILogger<BaseServiceBus> _logger;
    private readonly ServiceBusClient _client;
    private readonly ServiceBusSender _sender;
    private readonly string _queueName;
    private readonly object _reconnectLock = new object();

    protected BaseServiceBus(ServiceBusClient client, string queueName, ILogger<BaseServiceBus> logger)
    {
        _client = client;
        _logger = logger;
        _queueName = queueName;
        _sender = _client.CreateSender(_queueName);
    }

    public async Task SendAsync<T>(T message, DateTime? enqueueTimeUtc = null)
    {
        var m = CreateMessage(message, enqueueTimeUtc);

        await SendMessage(m, true);
    }

    protected virtual ServiceBusMessage CreateMessage<T>(T message, DateTime? enqueueTimeUtc)
    {
        var json = JsonConvert.SerializeObject(message);
        var sbMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(json))
        {
            ScheduledEnqueueTime = enqueueTimeUtc ?? DateTime.UtcNow,
            ContentType = "application/json",
            Subject = typeof(T).Name
        };

        return sbMessage;
    }

    private async Task SendMessage(ServiceBusMessage message, bool tryReconnect)
    {
        try
        {
            await _sender.SendMessageAsync(message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Service Bus connection lost, trying to reconnect");
            if (_sender.IsClosed && tryReconnect)
            {
                TryReconnect();
                await SendMessage(message, false);
            }
            else
            {
                throw;
            }
        }
    }

    private void TryReconnect()
    {
        lock (_reconnectLock)
        {
            if (_sender.IsClosed)
            {
                CreateSender();
            }
        }
    }

    private ServiceBusSender CreateSender() => _client.CreateSender(_queueName);

    public async ValueTask DisposeAsync() => await _sender.DisposeAsync().ConfigureAwait(false);
}