using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace YasamIcin.UI.MVC.Tools
{
    public class OnayMailHelper
    {
        public static bool UyelikOnayMail(string isim, string soyisim,string mail,string Mesaj,string Baslik)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = Baslik;
            msg.IsBodyHtml = true;
            msg.Body = Mesaj;
            msg.From = new MailAddress("yasamicinMVC@gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("yasamicinMVC@gmail.com", "Baris6061.");
            smtpClient.Credentials = credential;
            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception)
            {
                result = false;

            }

            return result;
        }
    }
}