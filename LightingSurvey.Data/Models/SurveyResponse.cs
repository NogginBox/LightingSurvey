namespace LightingSurvey.Data.Models
{
    public class SurveyResponse
    {
        public int Id { get; set; }

        /// <summary>
        /// An ID visible externally that can be used to complete this survey while it is active
        /// </summary>
        public string IdExternal { get; set; }

        public SurveyRespondent Respondent { get; set; }

        public bool? HappyWithLighting { get; set; }

        /// <summary>
        /// Scale 1 - 10, 1 being very dark, 10 being very bright
        /// </summary>
        public ushort? PerceivedBrightnessLevel { get; set; }
    }
}