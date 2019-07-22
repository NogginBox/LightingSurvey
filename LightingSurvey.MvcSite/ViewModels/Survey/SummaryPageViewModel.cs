using LightingSurvey.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class SummaryPageViewModel
    {
        public SummaryPageViewModel(SurveyResponse survey)
        {
            Name = survey.Respondent.Name;
            Email = survey.Respondent.EmailAddress;
            Address = survey.Respondent.Address.ToString();
            HappyWithLighting = survey.HappyWithLighting == true ? "yes" : "no";
            PercievedBrightness = survey.PerceivedBrightnessLevel.Value;
        }

        public string Name { get; }

        public string Email { get; }

        public string Address { get; }

        public string HappyWithLighting { get; }

        public ushort PercievedBrightness { get; }
    }
}
