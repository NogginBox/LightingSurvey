using LightingSurvey.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LightingSurvey.Data.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        private readonly IDataContext _data;

        public SurveyResponseRepository(IDataContext data)
        {
            _data = data;
        }

        public async Task<SurveyResponse> Create()
        {
            var surveyResponse = new SurveyResponse
            {
                IdExternal = Guid.NewGuid().ToString()
            };

            await _data.Responces.AddAsync(surveyResponse);
            return surveyResponse;
        }

        public async Task<SurveyResponse> Find(string externalId)
        {
            var response = await _data.Responces.FirstOrDefaultAsync(r => r.IdExternal == externalId);
            return response;
        }

        public async Task SaveChanges()
        {
            await _data.SaveChangesAsync();
        }
    }
}
