using LightingSurvey.Common.Services;
using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.ActionFilters;
using LightingSurvey.MvcSite.Extensions;
using LightingSurvey.MvcSite.Services;
using LightingSurvey.MvcSite.Services.Postcodes;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        private readonly IClientSideStorageService _clientStorage;
        private readonly IDateTimeService _dateTime;
        private readonly ILogger<SurveyController> _logger;
        private readonly IPostcodeLookupService _postcodeLookup;
        private readonly ISurveyResponseRepository _surveyResponseRepository;

        public SurveyController(IClientSideStorageService clientStorage, IDateTimeService dateTime, ILogger<SurveyController> logger, IPostcodeLookupService postcodeLookup, ISurveyResponseRepository surveyResponseRepository)
        {
            _clientStorage = clientStorage;
            _dateTime = dateTime;
            _logger = logger;
            _postcodeLookup = postcodeLookup;
            _surveyResponseRepository = surveyResponseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Start()
        {
            var responseId = _clientStorage.Read(SurveyResponse.StorageKey);
            CurrentResponse = await _surveyResponseRepository.Find(responseId);
            if(CurrentResponse == null)
            {
                CurrentResponse = await _surveyResponseRepository.Create();
                _clientStorage.Write(SurveyResponse.StorageKey, CurrentResponse.IdExternal, TimeSpan.FromDays(7));
                await _surveyResponseRepository.SaveChanges();
            }

            return RedirectToAction("Question1");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question1()
        {
            return QuestionView<NameQuestionViewModel, string>(CurrentResponse.Respondent.Name);
        }

        [HttpPost]
        [CheckValidAnswer(typeof(string))]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question1(NameQuestionViewModel question)
        {
            CurrentResponse.Respondent.Name = question.Answer;
            CurrentResponse.Modified(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question2");
        }


        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question2()
        {
            return QuestionView<EmailQuestionViewModel, string>(CurrentResponse.Respondent.EmailAddress);
        }

        [HttpPost]
        [CheckValidAnswer(typeof(string))]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question2(EmailQuestionViewModel question)
        {
            CurrentResponse.Respondent.EmailAddress = question.Answer;
            CurrentResponse.Modified(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question3");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question3()
        {
            return QuestionView<AddressQuestionViewModel, AddressViewModel>(CurrentResponse.Respondent.Address.ToViewModel());
        }

        [HttpPost]
        [CheckValidAnswer(typeof(AddressViewModel))]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question3(AddressQuestionViewModel question)
        {
            CurrentResponse.Respondent.Address = question.Answer.ToDataModel();
            var address = CurrentResponse.Respondent.Address;
            if(!string.IsNullOrEmpty(address.PostCode))
            {
                try
                {
                    var latLong = await _postcodeLookup.Search(address.PostCode);
                    address.Latitude = (decimal)latLong.Lat;
                    address.Longitude = (decimal)latLong.Long;
                }
                catch(Exception ex)
                {
                    _logger.LogWarning(ex, "Could not get location details from {postcode}", address.PostCode);
                }
            }

            CurrentResponse.Modified(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question4");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question4()
        {
            return QuestionView<BooleanQuestionViewModel, bool?>(CurrentResponse.HappyWithLighting);
        }

        [HttpPost]
        [CheckValidAnswer(typeof(bool?))]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question4(BooleanQuestionViewModel question)
        {
            CurrentResponse.HappyWithLighting = question.Answer;
            CurrentResponse.Modified(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Question5");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Question5()
        {
            return QuestionView<NumberQuestionViewModel, int?>(CurrentResponse.PerceivedBrightnessLevel);
        }

        [HttpPost]
        [CheckValidAnswer(typeof(int?))]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Question5(NumberQuestionViewModel question)
        {
            CurrentResponse.PerceivedBrightnessLevel = (ushort?)question.Answer;
            CurrentResponse.Modified(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();

            return RedirectToAction("Summary");
        }

        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public IActionResult Summary()
        {
            var model = new SummaryPageViewModel(CurrentResponse);
            return View(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(GetCurrentResponceAttribute))]
        public async Task<IActionResult> Confirm()
        {
            CurrentResponse.Complete(_dateTime.Now);
            await _surveyResponseRepository.SaveChanges();
            _clientStorage.Clear(SurveyResponse.StorageKey);

            return RedirectToAction("Done", "Home");
        }

        private IActionResult QuestionView<TQuestion, TAnswer>(TAnswer answer) where TQuestion : IQuestionViewModel<TAnswer>, new()
        {
            var model = new QuestionPageViewModel<TAnswer>
            {
                Question = new TQuestion { Answer = answer }
            };

            return View(model);
        }
    }
}
