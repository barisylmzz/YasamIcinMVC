using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YasamIcin.Model;

namespace YasamIcin.UI.MVC.Tools
{
    public class ResimEkle
    {
        public static Hasta  GetUploadPhoto(Hasta Hasta, HttpPostedFileBase file)
        {

            if (file != null)
            {
                file.SaveAs(HttpContext.Current.Server.MapPath("~/Img/") +
                                                              new Guid() + "_" + file.FileName);
                Hasta.Fotograf = new Guid() + "_" + file.FileName;
            }
            return Hasta; 
        }
    }
}