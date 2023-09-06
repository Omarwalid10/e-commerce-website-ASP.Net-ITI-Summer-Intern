using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_ITI_Project.Models;
using System.Runtime.Intrinsics.X86;
using NuGet.Protocol.Plugins;

namespace MVC_ITI_Project.Controllers
{
 
	public class productsController : Controller
    {
        private MarketDBContext DB = new MarketDBContext();

        //GET: products/Create
        public IActionResult Create(int Id)
        {
            //seller Id
            ViewBag.Id = Id;
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( Product product)
        {
            //if the all notnull properties of the product object not send from the form the modelstate will be not valid
            if (ModelState.IsValid)//why modelstate
            {
                string path="";

				if (product.ImageFile != null && product.ImageFile.Length > 0)
                {
					string originalFileName = Path.GetFileName(product.ImageFile.FileName);
					//using Guid.NewGuid because it return generates a new, universally unique identifier (UUID) each time it's called.
					path = Path.Combine("wwwroot/images/Uploads", Guid.NewGuid().ToString()+originalFileName);

                    //this part to save the image in the path create above
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await product.ImageFile.CopyToAsync(stream);
					}

				}
                //to get the new file name only without the all path
                product.image = Path.GetFileName(path);
				DB.Add(product);
				await DB.SaveChangesAsync();
				//to open the page of the same seller again 
				return RedirectToAction("Index", "seller", new { Id = product.sellerId });
            
				// return Content(path);
			}
            ViewData["sellerId"] = new SelectList(DB.sellers, "Id", "Id", product.sellerId);
			return RedirectToAction("Create", new { Id = product.sellerId }); 
        }

        // GET: products/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return Content("where Id");
            }

            var product = DB.products.Find(id);
            if (product == null)
            {
				return Content("where prod");
			}
            //ViewData["sellerId"] = new SelectList(_context.sellers, "Id", "Id", product.sellerId);
            return View(product);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
			//[Bind("Id,name,price,image,sellerId")] 
			if (ModelState.IsValid)
            {
                try
                {
					string path = "";

					if (product.ImageFile != null && product.ImageFile.Length > 0)
					{
						string originalFileName = Path.GetFileName(product.ImageFile.FileName);
						//using Guid.NewGuid because it return generates a new, universally unique identifier (UUID) each time it's called.
						path = Path.Combine("wwwroot/images/Uploads", Guid.NewGuid().ToString()+ originalFileName);

						//this part to save the image in the path create above
						using (var stream = new FileStream(path, FileMode.Create))
						{
							await product.ImageFile.CopyToAsync(stream);
						}
						//to get the new file name only without the all path
						product.image = Path.GetFileName(path);

					}
					DB.Update(product);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!productExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
				return RedirectToAction("Index", "seller", new { Id = product.sellerId });
			}
            ViewData["sellerId"] = new SelectList(DB.sellers, "Id", "Id", product.sellerId);
			return RedirectToAction("Edit", new { Id = product.Id });
		}

        private bool productExists(int id)
        {
            return (DB.products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
