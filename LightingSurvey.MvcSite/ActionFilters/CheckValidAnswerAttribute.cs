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
        public CheckValidAnswerAttribute()
        {
            Order = 2;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                if (!(context.ActionArguments["Question"] is IQuestionViewModel question))
                {
                    throw new Exception("This action was not passed a valid IQuestion");
                }

                if (!(context.Controller is Controller controller))
                {
                    throw new Exception("Attribute not on controller class");
                }

                var model = new QuestionPageViewModel
                {
                    Question = question
                };
                context.Result = controller.View(model);
            }

        }
    }
}