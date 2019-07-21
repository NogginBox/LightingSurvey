using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.Data.Models
{
    public class SurveyRespondent
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(254)]
        public string EmailAddress { get; set; }

        public Address Address { get; set; }
    }
}
