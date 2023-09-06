using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ITI_Project.Models
{
    public class Product
    {
        public int Id { get; set; }
		[MinLength(3, ErrorMessage = "Name must be more than 2 characters")]
		public string name { get; set; }
		[Range(5, 100000000000, ErrorMessage = "price must be more than 5")]
		public int price { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }
		public string image { get; set; }
        public int sellerId { get; set; }

        public virtual Seller? seller { get; set; }

        public virtual ICollection<Order>? orders { get; set; }

    }
}
