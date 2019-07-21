using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.ActionFilters;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LightingSurvey.MvcSite.Controllers
{
    public class SurveyController : Controller
    {
        /// <summary>
        /// Available to all actions and retrieved using GetSurveyResponceAttribute
        /// </summary>
        public SurveyResponse CurrentResponse { get; set; }

        private readonly ISurveyResponseRepository _surveyResponseRepository;
        private const string tempResponseId = "temp-id";

        public SurveyController(ISurveyResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Start()
        {
            CurrentResponse = await _surveyResponseRepository.Find(tempResponseId);
            if(CurrentResponse == null)
            {
                CurrentResponse = await _surveyResponseRepository.Create();
                // todo: save external ID in cookie
                await _surveyResponseRepository.SaveChanges();
            }

            return RedirectToAction("Question1");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question1()
        {
            return QuestionView<NameQuestionViewModel>(() =>
                 CurrentResponse.Respondent.Name
            );
        }

        [HttpPost]
        [CheckValidAnswer]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question1(NameQuestionViewModel question)
        {
            CurrentResponse.Respondent.Name = question.Answer;
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question2");
        }


        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question2()
        {
            return QuestionView<EmailQuestionViewModel>(() => 
                 CurrentResponse.Respondent.EmailAddress
            );
        }

        [HttpPost]
        [CheckValidAnswer]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question2(EmailQuestionViewModel question)
        {
            CurrentResponse.Respondent.EmailAddress = question.Answer;
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question3");
        }

        public IActionResult Question3()
        {
            return View();
        }

        public IActionResult Question4()
        {
            return View();
        }

        public IActionResult Question5()
        {
            return View();
        }

        public IActionResult Summary()
        {
            return View();
        }

        private IActionResult QuestionView<T>(Func<string> getValue) where T : IQuestionViewModel, new()
        {
            var model = new QuestionPageViewModel
            {
                Question = new T { Answer = getValue() }
            };

            return View(model);
        }
    }
}
