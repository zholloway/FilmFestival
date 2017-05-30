using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace FilmFestival.Services
{
    public class EmailServices
    {
        public void SendAccountEmail(int badgeID, string emailAddress)
        {
            var sender = "fantasticfest2017@gmail.com";
            var recipient = emailAddress;
            var subject = "FantasticFest2017 Purchase Confirmation";
            var body = $"Thank you for purchasing a badge to Fantastic Fest 2017! " +
                                    $"Your badge ID# is {badgeID}. " +
                                    $"Use your email address and your badge ID# as your username and password, respectively.";

            MailMessage accountEmail = new MailMessage(sender, recipient, subject, body);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("fantasticfest2017@gmail.com", "password123!");
            client.Send(accountEmail);
        }
    }
}