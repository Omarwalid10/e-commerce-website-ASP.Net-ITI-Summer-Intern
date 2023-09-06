namespace MVC_ITI_Project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ICollection<Product> products { get; set; }
        public int userId { get; set; }
        public virtual User? User { get; set; }

    }
}
