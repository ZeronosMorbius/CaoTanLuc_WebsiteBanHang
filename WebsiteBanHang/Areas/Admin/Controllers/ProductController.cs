using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebsiteBanHang.Context;

namespace Websitebanhang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities5 websiteBanHangEntities5 = new WebsiteBanHangEntities5();
        // GET: Admin/Product
        public ActionResult Index(String currentFilter, String SearchString, int? page)
        {
            var lstProduct = new List<Product>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!String.IsNullOrEmpty(SearchString))
            {

                lstProduct = websiteBanHangEntities5.Products.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = websiteBanHangEntities5.Products.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objproduct)
        {
            try
            {
                if (objproduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objproduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objproduct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    objproduct.Avatar = fileName;
                    objproduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                }
                websiteBanHangEntities5.Products.Add(objproduct);
                websiteBanHangEntities5.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objProduct = websiteBanHangEntities5.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objProduct = websiteBanHangEntities5.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objproduct)
        {
            var objProduct = websiteBanHangEntities5.Products.Where(n => n.Id == objproduct.Id).FirstOrDefault();
            websiteBanHangEntities5.Products.Remove(objProduct);
            websiteBanHangEntities5.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var objProduct = websiteBanHangEntities5.Products.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
            }
            websiteBanHangEntities5.Entry(objProduct).State = EntityState.Modified;
            websiteBanHangEntities5.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}