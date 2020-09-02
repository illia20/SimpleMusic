using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusic.Models
{
    public class Composer
    {
        public Composer()
        {
            Pieces = new List<Piece>();
        }
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name of composer")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Photo { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Short biography")]
        public string Bio { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public virtual ICollection<Piece> Pieces { get; set; }
    }
}
