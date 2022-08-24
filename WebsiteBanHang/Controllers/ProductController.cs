using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities5 websiteBanHangEntities5 = new WebsiteBanHangEntities5();
    
        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = websiteBanHangEntities5.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}