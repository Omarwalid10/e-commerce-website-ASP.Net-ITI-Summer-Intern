using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_ITI_Project.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
        public string password { get; set; }
        public ICollection<Product>? products { get; set; }


    }
}
