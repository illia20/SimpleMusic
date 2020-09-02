using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusic.Models
{
    public class Country
    {
        public Country()
        {
            Composers = new List<Composer>();
        }
        
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Display(Name = "Information")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }

        public virtual ICollection<Composer> Composers { get; set; }
    }
}
