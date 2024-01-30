namespace Zooflix.Models
{
    public class Profile
    {
        public int Id { get; set; } 
        public string? Name { get; set; }

        public virtual ICollection<User>? Users { get; set;}
        
    }
}
