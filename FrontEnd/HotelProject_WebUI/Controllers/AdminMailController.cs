using HotelProject_WebUI.Models.Mail;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;


namespace HotelProject_WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();
            
            //KİMDEN OLUCAĞI
            MailboxAddress mailboxAddressfrom = new MailboxAddress("HoteilerAdmin", "toredo159gmail.com");
            //ilk parametre kim tarafından gönderildi
            //ikinci ise maili gönderen adres
            mimeMessage.From.Add(mailboxAddressfrom);


            //KİME OLUCAĞI
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            //alıcının maili
            mimeMessage.To.Add(mailboxAddressTo);



            //MESAJIN İÇERİĞİ
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            //MESAJIN BAŞLIĞI
            mimeMessage.Subject = model.Subject;

            //smtp client yazarken using MailKit.Net.Smtp; bunu kullanmak zorundasın
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("toredo159@gmail.com", "mdrkkwhmxjedxjmr");
            client.Send(mimeMessage);
            client.Disconnect(true);
           


            return View();
        }
    }
}
