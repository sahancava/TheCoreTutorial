using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	[Table("Tags")]
	public class Tags
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[ForeignKey("ID")]
		public int ID { get; set; }
		public string Tag { get; set; }
	}
}
