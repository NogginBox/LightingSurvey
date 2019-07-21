using System;
using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class NameFormViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}