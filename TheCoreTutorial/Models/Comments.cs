using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class Comments
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CommentID { get; set; }
		public string CommentBody { get; set; }
		public News News { get; set; }
		[ForeignKey("NewsID")]
		public int NewsID { get; set; }
	}
}
