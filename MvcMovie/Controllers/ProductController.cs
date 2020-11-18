using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{

    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            if (Session["Products"] == null)
            {

                products.Add(new Product { ProductID = 1, Name = "Inca Kola", Price = 3, Active = true });
                products.Add(new Product { ProductID = 2, Name = "Pepsi", Price = 3, Active = true });
                products.Add(new Product { ProductID = 3, Name = "Coca Cola", Price = 3, Active = true });
                products.Add(new Product { ProductID = 4, Name = "Concordia", Price = 4, Active = true });
                products.Add(new Product { ProductID = 5, Name = "Fanta", Price = 4, Active = true });
                Session["Products"] = products;
            }
            else
            {
                products = ((List<Product>)Session["Products"]);
            }

            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product product = ((List<Product>)Session["Products"]).
                Where(x => x.ProductID == id).
                FirstOrDefault();

            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<Product>)Session["Products"]).Add(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = ((List<Product>)Session["Products"]).
                Where(x => x.ProductID == id).
                FirstOrDefault();

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                Product productFind = ((List<Product>)Session["Products"]).
                    Where(x => x.ProductID == id).
                    FirstOrDefault();

                productFind.Name = product.Name;
                productFind.Price = product.Price;
                productFind.Active = product.Active;


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product product = ((List<Product>)Session["Products"]).
                Where(x => x.ProductID == id).
                FirstOrDefault();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                List<Product> products = ((List<Product>)Session["Products"]);

                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].ProductID == id)
                    {
                        products.RemoveAt(i);
                    }
                }

                Session["Products"] = products;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}