using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;


namespace YasamIcin.UI.MVC.Tools
{
    public class SifreDegistirmeOnay
    {
        

        public static bool SifreDegistirmeMail(string userName, string password, string mail, int id)
        {
            //mailin yeni şifre olarak atanması yapılacak.
            
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.To.Add(mail);
            msg.Subject = "Hoşgeldiniz";
            msg.IsBodyHtml = true;
            msg.Body = "Şifreniz başarı ile değiştirilmiştir.Yeni şifreniz mail adresiniz olarak güncellenmiştir.";
            msg.From = new MailAddress("bilgeinsan1530@gmail.com");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("bilgeinsan1530@gmail.com", "Bilge1530insan.");
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