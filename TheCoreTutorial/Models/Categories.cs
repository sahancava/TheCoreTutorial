using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("ID")]
        public int ID { get; set; }
        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(500)]
        [Required]
        public string CategoryDescription { get; set; }
    }
}
