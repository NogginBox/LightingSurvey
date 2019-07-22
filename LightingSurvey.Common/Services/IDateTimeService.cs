using System;

namespace LightingSurvey.Common.Services
{
    /// <summary>
    /// Mimics the static methods on DateTime.
    /// Makes methods involving current dates testable and repeatable.
    /// </summary>
    public interface IDateTimeService
    {
        DateTime Now { get; }
    }
}
