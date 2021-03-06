﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class TagsNews
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		[ForeignKey("NewsID")]
		public int NewsID { get; set; }
		[ForeignKey("TagID")]
		public int TagID { get; set; }
	}
}
