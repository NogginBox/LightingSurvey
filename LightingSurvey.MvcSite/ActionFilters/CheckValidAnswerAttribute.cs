using LightingSurvey.MvcSite.Extensions;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LightingSurvey.MvcSite.ActionFilters
{
    /// <summary>
    /// Makes sure the answer passes model validation and returns current view if there are errors
    /// </summary>
    public class CheckValidAnswerAttribute : ActionFilterAttribute
    {
        private readonly Type _typeOf;

        public CheckValidAnswerAttribute(Type answerType)
        {
            Order = 2;
            _typeOf = answerType;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                if (!(context.Controller is Controller controller))
                {
                    throw new Exception("Attribute not on controller class");
                }

                var model = typeof(QuestionPageViewModel<>).CreateGenricInstance(_typeOf) as dynamic;
                try
                {
                    dynamic question = context.ActionArguments["Question"];
                    model.Question = question;
                }
                catch(Exception ex)
                {
                    throw new Exception("This action was not passed a valid IQuestion", ex);
                }

                context.Result = controller.View(model);
            }

        }
    }
}