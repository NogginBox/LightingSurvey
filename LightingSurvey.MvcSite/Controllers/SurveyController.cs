using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LightingSurvey.MvcSite.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyResponseRepository _surveyResponseRepository;

        private const string tempResponseId = "temp-id";

        public SurveyController(ISurveyResponseRepository surveyResponseRepository)
        {
            _surveyResponseRepository = surveyResponseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Start()
        {
            var response = await _surveyResponseRepository.Find(tempResponseId);
            if(response == null)
            {
                response = await _surveyResponseRepository.Create();
                // todo: save external ID in cookie
                await _surveyResponseRepository.SaveChanges();
            }

            return RedirectToAction("Question1");
        }

        public async Task<IActionResult> Question1()
        {
            // todo: extract this into attribute
            var response = await _surveyResponseRepository.Find(tempResponseId);
            if(response == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new QuestionPageViewModel<NameFormViewModel>
            {
                Question = new NameFormViewModel { Name = response.Respondent.Name }
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Question1(NameFormViewModel question)
        {
            if(!ModelState.IsValid)
            {
                var model = new QuestionPageViewModel<NameFormViewModel>
                {
                    Question = question
                };
                return View(model);
            }

            // todo: extract this into attribute
            var response = await _surveyResponseRepository.Find(tempResponseId);
            if (response == null)
            {
                return RedirectToAction("Index", "Home");
            }

            response.Respondent.Name = question.Name;
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question2");
        }

        public IActionResult Question2()
        {
            return View();
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
    }
}
