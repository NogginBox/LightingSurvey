namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    /// <summary>
    /// Generic question page view model for a page with a question of type T
    /// </summary>
    public class QuestionPageViewModel
    {
        public IQuestionViewModel Question { get; set; }
    }
}