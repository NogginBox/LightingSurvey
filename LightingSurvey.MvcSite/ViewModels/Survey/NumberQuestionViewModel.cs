using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class NumberQuestionViewModel : IQuestionViewModel<int?>
    {
        [Required(ErrorMessage = "Please answer this question")]
        public int? Answer { get; set; }
    }
}