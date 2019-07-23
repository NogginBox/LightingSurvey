using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class EmailQuestionViewModel : IQuestionViewModel<string>
    {
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(254)]
        public string Answer { get; set; }
    }
}