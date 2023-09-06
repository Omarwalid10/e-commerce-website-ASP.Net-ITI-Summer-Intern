using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ITI_Project.Models;

namespace MVC_ITI_Project.Controllers
{
	public class sellerController : Controller
	{
		MarketDBContext DB = new MarketDBContext();

		public IActionResult login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Seller seller)
		{
			if (ModelState.IsValid) {
				Seller orginalSeller;
				if (DB.sellers.FirstOrDefault(s => s.Email == seller.Email && s.password == seller.password)!=null)
				{
					orginalSeller = DB.sellers.FirstOrDefault(s => s.Email == seller.Email && s.password == seller.password);
					ViewData["products"] = DB.sellers.Include(x => x.products).FirstOrDefault(x => x.Id == orginalSeller.Id).products.ToList();
					return View(orginalSeller);
				}
				return Content("your Email or passward is wrong ");
			}
			return Content("error");
			
		}
		public IActionResult Index(int Id)
		{
			ViewData["products"] = DB.sellers.Include(x => x.products).FirstOrDefault(x => x.Id == Id).products.ToList();
			Seller seller = DB.sellers.Find(Id);
			return View(seller);
		}
		public IActionResult addSeller()
		{
			 return View();
		}
		[HttpPost]
		public IActionResult saveSeller(Seller seller)
		{
			if(ModelState.IsValid)
			{
				if (DB.sellers.FirstOrDefault(x => x.Email == seller.Email) == null) 
				{
					DB.Add(seller); 
					//this is important to make Id of seller enable to retrieve it
					DB.SaveChanges();
				}
				else
				{
					return Content("Error this Email was signed up ");
				}
				//return Content(seller.Id.ToString());
				//ViewData["products"] = DB.sellers.Include(x => x.products).FirstOrDefault(x => x.Id == seller.Id).products.ToList();
				//return View("Index", seller);
				//to make the route in path not have any data to make security 
				 
				return View("Login",seller);
			}
			return Content("Error");
		}



	}
}
