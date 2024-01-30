using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    [Table("Stars")]

    public class Etoile
    {
        public int Id { get; set; }

        [ForeignKey("Film")]
        [Column("star_mov_id")]
        public int FilmId { get; set; }

        [Column("star_first_name")]
        [Required]
        public string? Prenom { get; set; }

        [Column("star_last_name")]
        [Required]
        public string? Nom { get; set; }
        
    }
}
