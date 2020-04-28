using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
    [Table("Authors")]
    public class Authors
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorUsername { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorEmail { get; set; }
        [Required]
        [StringLength(50)]
        public string AuthorPassword { get; set; }
    }
}
