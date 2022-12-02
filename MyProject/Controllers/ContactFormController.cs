using Microsoft.AspNetCore.Mvc;
using MyProject.Interfaces;
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
        private readonly IGoogleCaptchaService _googleCaptchaService;
        public ContactFormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, IGoogleCaptchaService googleCaptchaService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _googleCaptchaService = googleCaptchaService;
        }

        public ActionResult Index()
        {

            return View();
        }
        public ActionResult RenderContact()
        {
            return RedirectToAction("Main");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(ContactForm contactForm)
        {
            var contentService = Services.ContentService;
            var parentId = Guid.Parse("c19d8e29-da43-47a2-80bb-8ed3e1c27594");
            TempData["ContactSuccess"] = false;
            if (!await _googleCaptchaService.VerifyToken(contactForm.Token))
            {
               
            }
                if (ModelState.IsValid)
            {
                // Create a new child item of type 'nieuwe contact'
                var contact = contentService.Create($"{contactForm.FullName} - {DateTime.Now.ToString()}", parentId, "ContactFormulier");
                contact.SetValue("fullname", contactForm.FullName);
                contact.SetValue("email", contactForm.Email);
                contact.SetValue("phoneNumber", contactForm.PhoneNumber);
                contact.SetValue("message", contactForm.Message);
                Services.ContentService.SaveAndPublish(contact);
                TempData["ContactSuccess"] = true;
                //SendMail(contactForm);
                return RedirectToUmbracoPage(parentId);
            }
            return CurrentUmbracoPage();

        }
        private void SendMail(ContactForm contactForm)
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
        }
    }
}
