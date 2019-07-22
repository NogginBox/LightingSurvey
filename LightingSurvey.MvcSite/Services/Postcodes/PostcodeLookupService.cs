using MarkEmbling.PostcodesIO;

namespace LightingSurvey.MvcSite.Services.Postcodes
{
    public class PostcodeLookupService
    {
        readonly IPostcodesIOClient _postcoder;

        public PostcodeLookupService()
        {
            _postcoder = new PostcodesIOClient();
        }
    }
}
