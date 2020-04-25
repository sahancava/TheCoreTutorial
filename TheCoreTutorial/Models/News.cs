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
        public int NewsID { get; set; }
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
        public virtual IList<NewsCategory> NewsCategories { get; set; }
        public virtual IList<AuthorNews> AuthorNew { get; set; }
        public virtual IList<CommentNew> CommentNews { get; set; }
        public virtual IList<TagsNews> TagNews { get; set; }

    }
}
