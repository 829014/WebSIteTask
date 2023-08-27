using NLog.Fluent;
using SimpleWebSite.HelperClass;
using SimpleWebSite.Models;
using SimpleWebSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleWebSite.Controllers
{
    public class HomeController : Controller
    {
        private IProducts _IProducts;

        public HomeController(IProducts iproducts)
        {
            _IProducts = iproducts;
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Index(int? page)
        {
            var resultViewModel = new ProductDataListPagingVm();
            try
            {
                List<Product> productList = new List<Product>();

                productList = _IProducts.GetProducts();

                var count = productList.Count();
                var paging = new Pager(count, page, 10);
                var items = productList.Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize).ToList();

                resultViewModel.ProductData = items;
                resultViewModel.Pager = paging;
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Error,'" + ex.Message + "',error";
            }

            return View(resultViewModel);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(string ItemName, string BrandName, string HSNNumber, string UOM, string Weight, decimal CGST, decimal SGST, decimal IGST, decimal BuyingPrice, decimal SellingPrice, decimal MRP, int Quantity, HttpPostedFileBase image)
        {
            try
            {               
                var model = new AddProductViewModel
                {
                    Name = ItemName,
                    BrandName = BrandName,
                    HSNNumber = HSNNumber,
                    UOM = UOM,
                    Weight = Weight,
                    CGST = CGST,
                    SGST = SGST,
                    IGST = IGST,
                    BuyingPrice = BuyingPrice,
                    SellingPrice = SellingPrice,
                    MRP = MRP,
                    Quantity = Quantity
                };

                if (!ReferenceEquals(image, null))
                {
                    var fileName = DateTime.Now.Ticks + "_" + image.FileName;
                    var path = Server.MapPath("~/Image/ProductItem/" + fileName);
                    image.SaveAs(path);
                    model.Image = fileName;
                }

                _IProducts.InsertProduct(model);

                return Json(new { success = true, responseText = "Added Successfully!" });
            }
            catch(Exception ex)
            {               
                return Json(new { success = false, responseText = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            Product _product = new Product();

            _product = _IProducts.GetProductFromId(Id);

            return View(_product);
        }

        [HttpPost]
        public ActionResult EditProduct(int Id, string ItemName, string BrandName, string HSNNumber, string UOM, string Weight, decimal CGST, decimal SGST, decimal IGST, decimal BuyingPrice, decimal SellingPrice, decimal MRP, int Quantity, HttpPostedFileBase image, string oldImg)
        {
            try
            {
                var model = new AddProductViewModel
                {
                    Id = Id,
                    Name = ItemName,
                    BrandName = BrandName,
                    HSNNumber = HSNNumber,
                    UOM = UOM,
                    Weight = Weight,
                    CGST = CGST,
                    SGST = SGST,
                    IGST = IGST,
                    BuyingPrice = BuyingPrice,
                    SellingPrice = SellingPrice,
                    MRP = MRP,
                    Quantity = Quantity
                };

                if (!ReferenceEquals(image, null))
                {
                    var fileName = DateTime.Now.Ticks + "_" + image.FileName;
                    var path = Server.MapPath("~/Image/ProductItem/" + fileName);
                    image.SaveAs(path);
                    model.Image = fileName;
                }
                else
                { model.Image = oldImg; }
               
                _IProducts.UpdateProduct(model);

                return Json(new { success = true, responseText = "Updated Successfully!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message });
            }
        }

        public ActionResult DeleteProduct(int Id)
        {
            try
            {
                _IProducts.DeleteProduct(Id);

                TempData["Message"] = "success,Delete Successfully!,success";
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Error,'" + ex.Message + "',error";
            }

            return RedirectToAction("Index");
        }
    }
}