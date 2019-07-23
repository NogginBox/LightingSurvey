using System.ComponentModel.DataAnnotations;

namespace LightingSurvey.Data.Models
{
    public class Address
    {
        [StringLength(128)]
        public string Line1 { get; set; }

        [StringLength(128)]
        public string Line2 { get; set;}

        [StringLength(64)]
        public string Town { get; set; }

        [StringLength(9)]
        public string PostCode { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return $"{Line1}\r\n{Line2}\r\n{Town}\r\n{PostCode}";
        }
    }
}
