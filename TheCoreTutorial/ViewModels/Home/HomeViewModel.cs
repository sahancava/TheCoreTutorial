using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheCoreTutorial.Models;
using PagedList;

namespace TheCoreTutorial.ViewModels.Home
{
	public class HomeViewModel
	{
		public IPagedList<News> News { get; set; }
        public List<Tuple<Categories, NewsCategory>> Categories { get; set; }
        public List<Config> Configs { get; set; }
        public List<Authors> Authors { get; set; } = new List<Authors>();
        public List<Tuple<Tags, TagsNews>> Tags { get; set; }
        public List<Comments> Comments { get; set; } = new List<Comments>();
    }
}
