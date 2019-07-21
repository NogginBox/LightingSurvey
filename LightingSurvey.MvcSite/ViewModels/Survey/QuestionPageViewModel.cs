namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    /// <summary>
    /// Generic question page view model for a page with a question of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QuestionPageViewModel<T> where T:IQuestionViewModel
    {
        public T Question { get; set; }
    }
}