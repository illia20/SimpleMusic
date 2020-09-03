using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusic.Models
{
    public class Piece
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Information")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }
        [Display(Name = "Composer")]
        public int ComposerId { get; set; }

        [ForeignKey("ComposerId")]
        public virtual Composer Composer { get; set; }
    }
}
