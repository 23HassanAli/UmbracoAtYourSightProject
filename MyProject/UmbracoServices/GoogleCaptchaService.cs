using Microsoft.Extensions.Options;
using MyProject.Interfaces;
using MyProject.Models;
using Newtonsoft.Json;

namespace MyProject.UmbracoServices
{
    public class GoogleCaptchaService : IGoogleCaptchaService
    {
        private readonly GooglereCaptchaSettings _googleCaptchaSettings;
        private readonly IHttpContextAccessor _httpContext;

        public GoogleCaptchaService(IOptions<GooglereCaptchaSettings> googleCaptchaSettings, IHttpContextAccessor httpContext)
        {
            _googleCaptchaSettings = googleCaptchaSettings.Value;
            _httpContext = httpContext;
        }
        public async Task<bool> VerifyToken(string token)
        {
            try
            {
                var remoteIp = _httpContext.HttpContext.Connection.RemoteIpAddress;
                var url = $"https://www.google.com/recaptcha/api/siteverify?secret={_googleCaptchaSettings.SecretKey}&response={token}";
                using (var client = new HttpClient())
                {
                    var httpResult = await client.GetAsync(url);
                    if (!httpResult.IsSuccessStatusCode)
                        return false;

                    var responseString = await httpResult.Content.ReadAsStringAsync();
                    var googleResult = JsonConvert.DeserializeObject<GooglereCaptchaResponse>(responseString);

                    return googleResult.Success && googleResult.Score >= 0.5;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
