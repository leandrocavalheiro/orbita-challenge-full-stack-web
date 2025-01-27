﻿using System;

namespace GrupoA.Academic.Commom.Extensions;

public static class DateTimeExtension
{
    public static DateTime? SetKind(this DateTime? dateTime)
    {
        return (dateTime.HasValue) ? dateTime.Value.SetKind() : null;
    }
    public static DateTime SetKind(this DateTime dateTime)
    {
        return (dateTime.Kind.Equals(DateTimeKind.Utc)) ? dateTime : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}