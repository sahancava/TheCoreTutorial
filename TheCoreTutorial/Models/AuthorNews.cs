using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class AuthorNews
	{
		public int NewsID { get; set; }
		public News News { get; set; }
		public int AuthorID { get; set; }
		public Authors Authors { get; set; }
	}
}
