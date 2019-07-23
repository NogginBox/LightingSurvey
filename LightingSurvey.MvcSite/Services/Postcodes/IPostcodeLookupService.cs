using System.Threading.Tasks;
using LightingSurvey.MvcSite.Services.Postcodes.Model;

namespace LightingSurvey.MvcSite.Services.Postcodes
{
    public interface IPostcodeLookupService
    {
        Task<LatLong> Search(string postcode);
    }
}
