using System;

namespace LightingSurvey.MvcSite.Services
{
    public interface IClientSideStorageService
    {
        void Clear(string key);

        string Read(string key);

        void Write(string key, string value, TimeSpan? timeToLive = null);
    }
}
