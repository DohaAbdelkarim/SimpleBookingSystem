using System;

namespace SimpleBookingSystem.API.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTimeOffset ToDateTimeOffset(this string dateTimeOffsetStr)
        {
            DateTimeOffset dateTimeOffset;
            if (!DateTimeOffset.TryParse(dateTimeOffsetStr, out dateTimeOffset))
            {
                dateTimeOffset = DateTimeOffset.Now;
            }
            return dateTimeOffset;
        }
    }
}