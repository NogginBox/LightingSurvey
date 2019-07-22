using System;

namespace LightingSurvey.Data.Models
{
    public class SurveyResponse
    {
        public SurveyResponse()
        {
            Dates = new SurveyDates();
            Respondent = new SurveyRespondent();
        }

        public static SurveyResponse CreateNew(DateTime now)
        {
            var newResponse = new SurveyResponse
            {
                IdExternal = Guid.NewGuid().ToString(),
            };
            newResponse.Dates.Create(now);

            return newResponse;
        }

        public int Id { get; set; }

        /// <summary>
        /// An ID visible externally that can be used to complete this survey while it is active
        /// </summary>
        public string IdExternal { get; set; }

        public SurveyDates Dates { get; private set; }

        public bool? HappyWithLighting { get; set; }

        public bool IsComplete => Dates.Completed != null;

        /// <summary>
        /// Scale 1 - 10, 1 being very dark, 10 being very bright
        /// </summary>
        public ushort? PerceivedBrightnessLevel { get; set; }

        public SurveyRespondent Respondent { get; private set; }

        public void Complete(DateTime completedDateTime)
        {
            Dates.Complete(completedDateTime);
            IdExternal = null;
        }

        public void Modified(DateTime modifiedDateTime)
        {
            Dates.Modify(modifiedDateTime);
        }
    }
}