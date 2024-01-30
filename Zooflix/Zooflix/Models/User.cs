using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Zooflix.Models;

namespace Zooflix.Models
{
    [Table("UserLogin")]
    public class User
    {
        public int Id { get; set; }

        [Column("user_name")]
        [Required]
        public string? Username { get; set; }

        [Column("user_password")]
        [Required]
        public string? Password { get; set; }

        [Column("user_first_name")]
        [Required]
        public string? FirstName { get; set; }

        [Column("user_last_name")]
        [Required]
        public string? LastName { get; set; }

        [Column("user_email")]
        [Required]
        public string? Email { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
       


    }
}