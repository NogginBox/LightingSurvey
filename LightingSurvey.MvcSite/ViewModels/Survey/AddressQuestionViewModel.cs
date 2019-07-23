using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class AddressQuestionViewModel : IQuestionViewModel<AddressViewModel>
    {
        public AddressQuestionViewModel()
        {
            Answer = new AddressViewModel();
        }

        public AddressViewModel Answer { get; set; }
    }
}