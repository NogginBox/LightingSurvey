using LightingSurvey.Common.Services;
using LightingSurvey.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LightingSurvey.Data.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly IDataContext _data;
        private readonly IDateTimeService _dateTime;

        public SurveyResponseRepository(IDataContext data, IDateTimeService dateTime)
        {
            _data = data;
            _dateTime = dateTime;
        }

        public async Task<SurveyResponse> Create()
        {
            var surveyResponse = SurveyResponse.CreateNew(_dateTime.Now);
            await _data.Responces.AddAsync(surveyResponse);
            return surveyResponse;
        }

        public async Task<SurveyResponse> Find(string externalId)
        {
            if(string.IsNullOrEmpty(externalId))
            {
                return null;
            }
            var response = await _data.Responces.FirstOrDefaultAsync(r => r.IdExternal == externalId);
            return response;
        }

        public async Task SaveChanges()
        {
            await _data.SaveChangesAsync();
        }
    }
}
