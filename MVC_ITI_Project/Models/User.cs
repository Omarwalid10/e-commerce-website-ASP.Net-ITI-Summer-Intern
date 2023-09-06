namespace MVC_ITI_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public string Email { get; set; }
		public string passward { get; set; }
        public ICollection<Order>? orders { get; set; }

    }
}
