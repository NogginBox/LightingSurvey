using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class EmailQuestionViewModel : IQuestionViewModel<string>
    {
        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Answer { get; set; }
    }
}