using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Converter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


       
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Server.MapPath("~/Images/") + fileName;
                file.SaveAs(filePath);

                // Convert the image to base64
                string base64Image = ConvertImageToBase64(filePath);

                // Display the base64 string below the upload button
                ViewBag.Base64Image = base64Image;

                ViewBag.ImageUrl = "~/Images/" + fileName;
            }

            return View("Index");
        }

        private string ConvertImageToBase64(string imagePath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath);
            string base64Image = System.Convert.ToBase64String(imageBytes);
            return base64Image;
        }

        


    }
}