using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    public class OrderFilm
    {
       
        [ForeignKey("Order")]
        [Column("ord_id")]
        public int OrderId { get; set;}

        [ForeignKey("Film")]
        [Column("film_id")]
        public int FilmId { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Film? Film { get; set; }
    }
}
