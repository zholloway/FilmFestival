using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace FilmFestival.Services
{
    public class EmailServices
    {
        public void SendAccountEmail()
        {
            var sender = "fantasticfest2017@gmail.com";
            var recipient = "zholloway92@gmail.com";
            var body = "You did it!";
            var subject = "Guess what?";

            MailMessage accountEmail = new MailMessage(sender, recipient, subject, body);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("fantasticfest2017@gmail.com", "password123!");
            client.Send(accountEmail);
        }
    }
}