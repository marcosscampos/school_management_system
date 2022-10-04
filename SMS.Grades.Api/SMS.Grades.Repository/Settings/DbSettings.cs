using SMS.Grades.Domain.Abstractions.Settings;

namespace SMS.Grades.Repository.Settings;

public class DbSettings : IDbSettings
{
    public string ConnectionStringSQLite { get; set; }
}