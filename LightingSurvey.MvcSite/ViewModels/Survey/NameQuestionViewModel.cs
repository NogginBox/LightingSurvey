using System;
using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.MvcSite.ViewModels.Survey
{
    public class NameQuestionViewModel : IQuestionViewModel
    {
        [Required]
        [StringLength(50)]
        public string Answer { get; set; }
    }
}