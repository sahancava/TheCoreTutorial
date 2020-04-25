using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class CommentNew
	{
		public int CommentID { get; set; }
		public Comments Comments { get; set; }
		public int NewsID { get; set; }
		public News News { get; set; }
	}
}
