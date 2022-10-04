namespace SMS.Activities.Domain.Abstractions.Settings;

public abstract class Entity
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
}