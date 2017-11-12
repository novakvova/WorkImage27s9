using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteImage.Helpers;
using WebSiteImage.Models;

namespace WebSiteImage.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GalleryCreateViewModel galleryCreate)
        {
            var image = galleryCreate.Image;
            var imageSave = WorkImage.CreateImage(galleryCreate.Image, 800, 600);
            if(imageSave!=null)
            {
                string path = Server.MapPath("~/Upload/ImageGallery/");
                string fileName = Guid.NewGuid().ToString() + ".jpg";
                imageSave.Save(path + fileName, ImageFormat.Jpeg);
            }
            return View();
        }
    }
}