using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace LightingSurvey.MvcSite.ActionFilters
{
    /// <summary>
    /// Makes sure there is a currently active survey response, or redirects to start of survey
    /// </summary>
    public class GetCurrentResponceAttribute : ActionFilterAttribute
    {
        private readonly ISurveyResponseRepository _surveyResponseRepository;
        private const string tempResponseId = "temp-id";

        public GetCurrentResponceAttribute(ISurveyResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
            Order = 1;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is SurveyController surveyController)
            {
                surveyController.CurrentResponse = await _surveyResponseRepository.Find(tempResponseId);
                if (surveyController.CurrentResponse == null)
                {
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Home", action = "Error" })
                    );
                }
            }

            await next();
        }
    }
}