using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities5 websiteBanHangEntities5 = new WebsiteBanHangEntities5();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = websiteBanHangEntities5.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id)
        {
            var listProduct = websiteBanHangEntities5.Products.Where(n=>n.CategoryId == Id ).ToList();
            return View(listProduct);
        }
    }
}