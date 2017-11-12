using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteImage.Models
{
    public class GalleryCreateViewModel
    {
        public string Title { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}