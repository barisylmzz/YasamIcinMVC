using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using YasamIcin.UI.MVC.Models;

namespace YasamIcin.UI.MVC
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Yasal Uyarı", Metin = "Yasal Uyarı Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur." });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Biz Kimiz", Metin = "Biz Kimiz Yasal Uyarı Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur." });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Misyonumuz", Metin = "Misyonumuz Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur." }); SayfaDetayText.Insert(new SayfaDetay { Baslik = "Vizyonumuz", Metin = "Vizyonumuz Yasal Uyarı Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur." });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Telefon", Metin = "0000 000 00000 000000" });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Fax", Metin = "1000 000 00000 000000" }); SayfaDetayText.Insert(new SayfaDetay { Baslik = "Mail", Metin = "muharrem.ercan@hotmail.com" }); SayfaDetayText.Insert(new SayfaDetay { Baslik = "Kanunlar", Metin = "https://muratyayinlari.com/storage/catalogs/0022380001521095951.pdf" });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Kararnameler", Metin = "https://muratyayinlari.com/storage/catalogs/0022380001521095951.pdf" });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "Yönergeler", Metin = "https://muratyayinlari.com/storage/catalogs/0022380001521095951.pdf" }); SayfaDetayText.Insert(new SayfaDetay { Baslik = "Genelgeler", Metin = "https://muratyayinlari.com/storage/catalogs/0022380001521095951.pdf" });
            SayfaDetayText.Insert(new SayfaDetay { Baslik = "DİYKK", Metin = "https://muratyayinlari.com/storage/catalogs/0022380001521095951.pdf" });
            AreaRegistration.RegisterAllAreas();
           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            Response.Redirect(urlHelper.Action("Index", "Error",new { ErrorText=exception.Message , Area= "" }));

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}