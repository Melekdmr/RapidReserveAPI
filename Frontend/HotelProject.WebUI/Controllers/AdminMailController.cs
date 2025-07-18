using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System.Net.Http;
using System.Net.Mail;
using System.Text;

namespace HotelProject.WebUI.Controllers
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
			MailboxAddress mailboxAdressFrom = new MailboxAddress("hotelieradmin", "xxxxxx@gmail.com"); //Mail adresinizi girin
			mimeMessage.From.Add(mailboxAdressFrom); //kimden

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo); //kime


			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = model.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody(); //mesaj içeriği
			mimeMessage.Subject = model.Subject; //başlık

			MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
             client.Connect("smtp.gmail.com", 587, false);// 587 port numarası , ssl gereksin mi = fasle istersen true yaparsın
			client.Authenticate("xxxxxx@gmail.com", "xxxxxxxx"); //Mail adreisniz ve uygulama şifrenizi girin
			client.Send(mimeMessage);
			client.Disconnect(true);
			return View();





	}
}
}
