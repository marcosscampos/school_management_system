﻿using System.Runtime.Serialization;

namespace SMS.Grades.CrossCutting.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {

    }

    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}