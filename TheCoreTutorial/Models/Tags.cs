using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class Tags
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TagID { get; set; }
		public string Tag { get; set; }
		public virtual IList<TagsNews> TagNews { get; set; }
	}
}
