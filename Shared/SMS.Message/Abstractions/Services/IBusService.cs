namespace SMS.Message.Abstractions.Services;

public interface IBusService
{
    Task SendMessageToQueueAsync(object obj, string queue);
}