﻿namespace SMS.Submissions.Domain.Abstractions.Settings;

public interface IDbSettings
{
    string ConnectionStringSQLite { get; set; }
}