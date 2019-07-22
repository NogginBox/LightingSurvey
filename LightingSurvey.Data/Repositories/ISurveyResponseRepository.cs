using LightingSurvey.Data.Models;
using System.Threading.Tasks;

namespace LightingSurvey.Data.Repositories
{
    public interface ISurveyResponseRepository
    {
        Task<SurveyResponse> Create();

        Task<SurveyResponse> Find(string externalId);

        Task SaveChanges();
    }
}