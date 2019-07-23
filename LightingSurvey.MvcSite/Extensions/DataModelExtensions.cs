using LightingSurvey.Data.Models;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Html;
using System.Net;

namespace LightingSurvey.MvcSite.Extensions
{
    public static class DataModelExtensions
    {
        public static Address ToDataModel(this AddressViewModel model)
        {
            return new Address
            {
                Line1 = model.Line1,
                Line2 = model.Line2,
                Town = model.Town,
                PostCode = model.Postcode
            };
        }

        public static AddressViewModel ToViewModel(this Address address)
        {
            return new AddressViewModel
            {
                Line1 = address.Line1,
                Line2 = address.Line2,
                Town = address.Town,
                Postcode = address.PostCode
            };
        }

        public static HtmlString ToHtmlString(this Address address)
        {
            var addressString = address.ToString()
                .Replace("\r\n", "====");

            var htmlSafeAddress = WebUtility.HtmlEncode(addressString)
                .Replace("========", "<br />")
                .Replace("====", "<br />");

            return new HtmlString(htmlSafeAddress);
        }
    }
}
