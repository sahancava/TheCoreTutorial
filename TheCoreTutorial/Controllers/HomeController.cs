using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PagedList;
using TheCoreTutorial.Models;
using TheCoreTutorial.Models.DBHandler;
using TheCoreTutorial.ViewModels.Home;

namespace TheCoreTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        public HomeController(DatabaseContext context)
        {
            this._context = context;
        }
        public ActionResult Index(int page = 1)
        {
            var recordsPerPage = (from a in _context.Config where a.RecordsPerPage != null select a.RecordsPerPage).First();
            
            HomeViewModel model = new HomeViewModel
            {
                Configs = (from a in _context.Config select a).ToList(),
                News = (from a in _context.News where a.IsActive==true select a).ToList().ToPagedList(page, (int)recordsPerPage),
                Categories = (from i in _context.News
                              join c in _context.NewsCategories
                              on i.ID equals c.NewsID
                              join e in _context.Categories
                              on c.CategoryID equals e.ID
                              where c.NewsID == i.ID
                              select
                              new Tuple<Categories, NewsCategory>(
                                  new Categories
                                  {
                                      ID = c.CategoryID,
                                      CategoryName = e.CategoryName
                                  },
                                  new NewsCategory
                                  {
                                      NewsID = c.NewsID
                                  })).ToList(),
                Authors = (from a in _context.Authors select a).ToList(),
                Tags = (from i in _context.News
                        join c in _context.TagNews
                        on i.ID equals c.NewsID
                        join e in _context.Tags
                        on c.TagID equals e.ID
                        where c.NewsID == i.ID
                        select
                        new Tuple<Tags, TagsNews>(
                            new Tags
                            {
                                ID = c.TagID,
                                Tag = e.Tag
                            },
                            new TagsNews
                            {
                                NewsID = c.NewsID
                            })).ToList(),
                //Tags = (from a in _context.Tags select a).ToList(),
                Comments = (from a in _context.Comments select a).ToList()
            };

            return View(model);
        }

        /*public ActionResult GetQuery(string search)
        {
            bool isAjaxCall = HttpContext.Request.Headers["x-requested-with"] == "XMLHttpRequest";

            if (isAjaxCall)
            {
                //this.Configuration.ProxyCreationEnabled = false;
                var result = _context.News.Where(x => x.NewsBody.Contains(search) || x.NewsTitle.Contains(search) || x.Tags.Any(y => y.Tag.Contains(search))).Distinct().ToList();
                return Json(result, new Newtonsoft.Json.JsonSerializerSettings());
            }
            return RedirectToAction("Index");
        }*/
    }
}