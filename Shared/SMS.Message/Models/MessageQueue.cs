namespace SMS.Message.Models;

public class MessageQueue<T>
{
	public MessageQueue(Guid messageId, T entity)
	{
		MessageId = messageId;
		Entity = entity;
	}

	public Guid MessageId { get; set; }
	public T Entity { get; set; }
}
