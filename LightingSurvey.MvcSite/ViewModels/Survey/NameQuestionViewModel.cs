using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class NameQuestionViewModel : IQuestionViewModel<string>
    {
        [Required(ErrorMessage = "Please answer this question")]
        [StringLength(50, ErrorMessage = "Your name can not be this long")]
        public string Answer { get; set; }
    }
}