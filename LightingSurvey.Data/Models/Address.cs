using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.Data.Models
{
    public class Address
    {
        [StringLength(9)]
        public string PostCode { get; set; }
    }
}
