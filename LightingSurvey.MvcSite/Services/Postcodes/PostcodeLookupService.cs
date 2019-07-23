using MarkEmbling.PostcodesIO;
using System.Threading.Tasks;
using LightingSurvey.MvcSite.Services.Postcodes.Model;

namespace LightingSurvey.MvcSite.Services.Postcodes
{
    public class PostcodeLookupService : IPostcodeLookupService
    {
        readonly IPostcodesIOClient _postcoder;

        public PostcodeLookupService()
        {
            _postcoder = new PostcodesIOClient();
        }

        public async Task<LatLong> Search(string postcode)
        {
            var details = await _postcoder.LookupAsync(postcode);
            return new LatLong(details.Latitude, details.Longitude);
        }
    }
}
