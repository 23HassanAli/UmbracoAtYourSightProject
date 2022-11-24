using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Net;
using System.Net.Mail;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace MyProject.Controllers
{
    public class ContactFormController : SurfaceController
    {
        public ContactFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {

        }
        [HttpPost]
        public ActionResult Submit(ContactForm contactForm)
        {
            const string mailServer = "smtp.gmail.com";
            const int portNumber = 587;
            const string userName = "pagerentboeken@gmail.com";
            const string password = "mliclufiryopaudu";
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                mailMessage.From = new MailAddress(contactForm.Email);
                mailMessage.To.Add(userName);
                mailMessage.Subject = "Client Contacted";
                mailMessage.Body = contactForm.Message;
               
                smtpClient.UseDefaultCredentials = false;
                NetworkCredential networkCredential = new NetworkCredential(userName, password);
                smtpClient.Credentials = networkCredential;
           
                smtpClient.EnableSsl = true;
                smtpClient.Port = portNumber;
                smtpClient.Host = mailServer;
           


                smtpClient.Send(mailMessage);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
            return View();
        }
    }
}
