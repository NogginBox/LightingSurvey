using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class AddressViewModel
    {
        [Required(ErrorMessage = "Please fill this in"), StringLength(128)]
        public string Line1 { get; set; }

        [StringLength(128)]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Please fill this in"), StringLength(64)]
        public string Town { get; set; }

        [StringLength(9)]
        public string Postcode { get; set; }
    }
}