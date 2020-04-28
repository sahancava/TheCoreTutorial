using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
    [Table("News")]
    public class News
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(150), Required]
        public string NewsTitle { get; set; }
        [StringLength(4000), Required]
        public string NewsBody { get; set; }
        [Required]
        public Nullable<int> NewsViewCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PublishDate { get; set; }
        public string ImageURL { get; set; }
        public bool IsActive { get; set; }


        //Navigation Properties
        /*[ForeignKey("CategoryID")]
        public Categories Category { get; set; }
        public int CategoryID { get; set; }*/

        [ForeignKey("AuthorID")]
        public Authors Author { get; set; }
        public int AuthorID { get; set; }
        public List<TagsNews> Tags { get; set; }
        public virtual List<Comments> Comment { get; set; } = new List<Comments>();

    }
}
