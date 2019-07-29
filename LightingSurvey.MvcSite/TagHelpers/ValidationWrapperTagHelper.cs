using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace LightingSurvey.MvcSite.TagHelpers
{
    /// <summary>
    /// <see cref="ITagHelper"/> implementation targeting any HTML element with an <c>asp-validation-for</c>
    /// attribute.
    /// </summary>
    [HtmlTargetElement("div", Attributes = ValidationForAttributeName)]
    public class ValidationWrapperTagHelper : TagHelper
    {
        private const string ValidationForAttributeName = "asp-validation-wrapper-for";

        /// <summary>
        /// Creates a new <see cref="ValidationWrapperTagHelper"/>.
        /// </summary>
        /// <param name="generator">The <see cref="IHtmlGenerator"/>.</param>
        public ValidationWrapperTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        /// <inheritdoc />
        public override int Order => -1000;

        /// <summary>
        /// Gets the <see cref="Rendering.ViewContext"/> of the executing view.
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Gets the <see cref="IHtmlGenerator"/> used to generate the <see cref="ValidationMessageTagHelper"/>'s output.
        /// </summary>
        protected IHtmlGenerator Generator { get; }

        /// <summary>
        /// Gets an expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName(ValidationForAttributeName)]
        public ModelExpression For { get; set; }

        /// <inheritdoc />
        /// <remarks>Does nothing if <see cref="For"/> is <c>null</c>.</remarks>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (For != null && FieldHasError(ViewContext, For.Name))
            {
                output.Attributes.AddClass("govuk-form-group--error");
            }
        }


        private bool FieldHasError(ViewContext viewContext, string expression)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            var fullName = NameAndIdProvider.GetFullHtmlFieldName(viewContext, expression);
            var tryGetModelStateResult = viewContext.ViewData.ModelState.TryGetValue(fullName, out var entry);
            var modelErrors = tryGetModelStateResult ? entry.Errors : null;

            return (modelErrors != null && modelErrors.Count != 0);
        }
    }
}