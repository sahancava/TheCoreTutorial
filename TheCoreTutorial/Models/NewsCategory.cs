using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class NewsCategory
	{
		public int NewsID { get; set; }
		public News News { get; set; }
		public int CategoryID { get; set; }
		public Categories Categories { get; set; }
	}
}
