using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class BooleanQuestionViewModel : IQuestionViewModel<bool?>
    {
        [Required(ErrorMessage = "Please answer this question")]
        public bool? Answer { get; set; }
    }
}