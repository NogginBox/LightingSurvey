using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class NumberQuestionViewModel : IQuestionViewModel<int?>
    {
        [Required]
        public int? Answer { get; set; }
    }
}