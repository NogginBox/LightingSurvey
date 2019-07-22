using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class BooleanQuestionViewModel : IQuestionViewModel<bool?>
    {
        [Required]
        public bool? Answer { get; set; }
    }
}