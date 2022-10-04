using SMS.Submissions.Domain.Abstractions.Settings;

namespace SMS.Submissions.Repository.Settings;

public class DbSettings : IDbSettings
{
    public string ConnectionStringSQLite { get; set; }
}