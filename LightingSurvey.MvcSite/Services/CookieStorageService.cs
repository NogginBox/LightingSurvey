using LightingSurvey.Common.Services;
using Microsoft.AspNetCore.Http;
using System;

namespace LightingSurvey.MvcSite.Services
{
    public class CookieStorageService : IClientSideStorageService
    {
        private readonly IDateTimeService _dateTime;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieStorageService(IDateTimeService dateTime, IHttpContextAccessor httpContextAccessor)
        {
            _dateTime = dateTime;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Clear(string key)
        {
            Write(key, string.Empty, TimeSpan.FromSeconds(5));
        }

        public string Read(string key)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            return request.Cookies[key];
        }

        public void Write(string key, string value, TimeSpan? timeToLive)
        {
            var options = timeToLive?.TotalSeconds > 0
                ? new CookieOptions { Expires = _dateTime.Now.Add(timeToLive.Value) }
                : null;

            var response = _httpContextAccessor.HttpContext.Response;
            response.Cookies.Append(key, value, options);
        }
    }
}