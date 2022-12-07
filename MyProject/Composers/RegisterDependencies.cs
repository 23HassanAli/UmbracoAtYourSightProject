using MyProject.Interfaces;
using MyProject.UmbracoServices;
using Umbraco.Cms.Core.Composing;

namespace MyProject.Composers
{
    public class RegisterDependencies : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddTransient<IGoogleCaptchaService, GoogleCaptchaService>(); 
            
            
        }
    }
}
