using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_ITI_Project.Models;

namespace MVC_ITI_Project.Controllers
{
    public class userController : Controller

    {
        MarketDBContext DB = new MarketDBContext();
        public static List<Product> CartProducts = new List<Product>();
		
		public IActionResult login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(User user)
		{
			if (ModelState.IsValid)
			{
				User orginalUser;
				if (DB.users.FirstOrDefault(s => s.Email == user.Email && s.passward == user.passward) != null)
				{
					orginalUser = DB.users.FirstOrDefault(s => s.Email == user.Email && s.passward == user.passward);
					ViewData["products"] = DB.products.ToList();
					return View(orginalUser);
				}
				return Content("your Email or passward is wrong ");
			}
			return Content("error");

		}
		public IActionResult Index(int Id)
        {
            ViewData["products"] = DB.products.ToList();
            User user = DB.users.Find(Id);
            return View(user);
             
        }
		public IActionResult addProductToCart(int productId,int Id)
		{
		    CartProducts.Add(DB.products.Find(productId));//because you cant send complex opeject like product
             
		   //Id is user Id
            return RedirectToAction("Index", new { Id = Id });////////////// 
		}
		//this Id of the user
		public IActionResult showCart(int Id)
		{
			int sum=0;
			foreach (var i in CartProducts)
			{
				sum += i.price;
			}
			ViewBag.sum = sum;
			//user Id
			ViewBag.Id= Id;
			return View(CartProducts);
		}
		public IActionResult deleteProductCart(int productId,int userId)
		{
			foreach (var i in CartProducts)
			{
				if(i.Id == productId)
				{
					CartProducts.Remove(i);
					break;
				}
			}
			return RedirectToAction("showCart", new { Id = userId });
			//return Content(DB.products.Find(productId).price.ToString());
		
		}
		public IActionResult Buy(int userId)
		{
			CartProducts.Clear();
			return RedirectToAction("Index", new { Id = userId });
		}

		public IActionResult addUser()
		{
			return View();
		}
		[HttpPost]
		public IActionResult saveUser(User user)
		{
			if (ModelState.IsValid)
			{
				if (DB.users.FirstOrDefault(x => x.Email == user.Email) == null)
				{
					DB.Add(user);
					//this is important to make Id of seller enable to retrieve it
					DB.SaveChanges();
				}
				else
				{
					return Content("Error this Email was signed up ");
				}
				//to make the route in path not have any data to make security 
				return View("Login", user);
			}
			return Content("Error");
		}


	}
}
