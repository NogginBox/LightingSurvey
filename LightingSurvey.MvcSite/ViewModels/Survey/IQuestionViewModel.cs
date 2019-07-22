namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public interface IQuestionViewModel<T>
    {
        T Answer { get; set; }
    }
}