using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;

namespace LightingSurvey.MvcSite.TagHelpers
{
    public static class TagHelperExtensions
    {
        /// <summary>
        /// Adds a class to a tag, if it is not already there (case sensitive)
        /// </summary>
        /// <param name="attributes">The attribute list to add the class to</param>
        /// <param name="htmlClass">The class to add to the tag</param>
        /// <remarks>Keep checking to see if this or similar is added to the framework</remarks>
        public static void AddClass(this TagHelperAttributeList attributes, string htmlClass)
        {
            attributes.TryGetAttribute("class", out var classAttribute);
            var classes = classAttribute?.Value?.ToString();
            if (string.IsNullOrWhiteSpace(classes))
            {
                attributes.SetAttribute("class", htmlClass);
                return;
            }

            var classList = classes.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (!classList.Contains(htmlClass, StringComparer.Ordinal))
            {
                attributes.SetAttribute("class", new HtmlString($"{classes} {htmlClass}"));
            }
        }
    }
}