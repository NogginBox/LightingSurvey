using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.Controllers;
using LightingSurvey.MvcSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace LightingSurvey.MvcSite.ActionFilters
{
    /// <summary>
    /// Makes sure there is a currently active survey response, or redirects to start of survey
    /// </summary>
    public class GetCurrentResponceAttribute : ActionFilterAttribute
    {
        private readonly IClientSideStorageService _clientStorage;
        private readonly ISurveyResponseRepository _surveyResponseRepository;

        public GetCurrentResponceAttribute(IClientSideStorageService clientStorage, ISurveyResponseRepository surveyResponseRepository)
        {
            _clientStorage = clientStorage;
            _surveyResponseRepository = surveyResponseRepository;
            Order = 1;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is SurveyController surveyController)
            {
                var responseId = _clientStorage.Read(SurveyResponse.StorageKey);
                surveyController.CurrentResponse = await _surveyResponseRepository.Find(responseId);
                if (surveyController.CurrentResponse == null)
                {
                    _clientStorage.Clear(SurveyResponse.StorageKey);
                    context.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "Home", action = "Index" })
                    );
                    return;
                }
            }

            await next();
        }
    }
}