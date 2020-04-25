using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCoreTutorial.Models
{
	public class Config
	{
        [Key]
        public int ID { get; set; }
        [StringLength(200)]
        public string WebSiteAddress { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(500)]
        public string Keywords { get; set; }
        public int RecordsPerPage { get; set; }
    }
}
