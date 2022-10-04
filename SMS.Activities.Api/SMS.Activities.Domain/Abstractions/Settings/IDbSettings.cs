namespace SMS.Activities.Domain.Abstractions.Settings;

public interface IDbSettings
{
    string ConnectionStringSQLite { get; set; }
}