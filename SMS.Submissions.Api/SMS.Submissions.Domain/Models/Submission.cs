﻿using SMS.Submissions.Domain.Abstractions.Settings;

namespace SMS.Submissions.Domain.Models;

public class Submission : Entity
{
    public string Content { get; set; }
    public long StudentId { get; set; }
    public long ClassRoomId { get; set; }
    public long ActivityId { get; set; }
    public long GradeId { get; set; }
}