using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class TagsNews
	{
		public int NewsID { get; set; }
		public News News { get; set; }
		public Tags Tags { get; set; }
		public int TagID { get; set; }
	}
}
