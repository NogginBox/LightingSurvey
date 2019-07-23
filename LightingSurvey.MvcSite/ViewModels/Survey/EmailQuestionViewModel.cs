using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class EmailQuestionViewModel : IQuestionViewModel<string>
    {
        [Required(ErrorMessage = "Please answer this question")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        [StringLength(254, ErrorMessage = "Your email address can not be this long")]
        public string Answer { get; set; }
    }
}