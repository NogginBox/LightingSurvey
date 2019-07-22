using System;

namespace LightingSurvey.Common.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}