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
        public int CategoryID { get; set; }
        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }
        [StringLength(500)]
        [Required]
        public string CategoryDescription { get; set; }
        public virtual IList<NewsCategory> NewsCategories { get; set; }
    }
}
