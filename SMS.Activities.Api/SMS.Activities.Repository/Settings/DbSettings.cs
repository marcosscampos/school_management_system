using SMS.Activities.Domain.Abstractions.Settings;

namespace SMS.Activities.Repository.Settings;

public class DbSettings : IDbSettings
{
    public string ConnectionStringSQLite { get; set; }
}