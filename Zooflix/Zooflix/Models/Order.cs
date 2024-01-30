using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    public class Order
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("ord_user_id")]
        public int UserId { get; set; }

        [Required]
        public DateTime? ord_date { get; set; }

        public virtual ICollection<OrderFilm>? OrderFilms { get; set; }

    }
}