
using NewsTagsApp.BusinessLogic;
using NewsTagsApp.Models;
using NewsTagsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewsTagsApp.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index(int page = 1)
        {
            int pageSize = 10;
            NewsTagsMethods newsTagsMethods = new NewsTagsMethods();
           
            NewsTagsViewModel newsTagsViewModel = newsTagsMethods.GetAllNewsTags(page, pageSize);
            newsTagsViewModel.Pager = new Pager(newsTagsViewModel.TotalRecords, page);
            newsTagsViewModel.Pager.CurrentPage = page;
            string search = "";
            if(Session["search"]!=null)
            {
                search= Session["search"].ToString();
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                newsTagsViewModel.ListNewsTags = newsTagsViewModel.ListNewsTags.Where(c => c.NewsTitle.ToLower().Contains(search.ToLower()) || c.TagName.ToLower().Contains(search.ToLower())).ToList();
                ViewBag.search = search;
            }

            
            return View(newsTagsViewModel);
        }
        
        public PartialViewResult DataSearch(string news ,int page = 1)
        {
            //int pageSize = 10;


            NewsTagsViewModel newsTagsViewModel = new NewsTagsViewModel();
            List<NewsTagsViewModel> ListNewsTags = new List<NewsTagsViewModel>();
            int rowNo = (page - 1) * page;

            using (NewsDbContext context = new NewsDbContext())
            {
                newsTagsViewModel.TotalRecords = context.News.Count();

                var data = (from nt in context.NewsTags
                            join n in context.News
                            on nt.NewsID equals n.NewsID
                            join t in context.Tags
                            on nt.TagID equals t.TagID
                            select new NewsTagsViewModel { NewsID = n.NewsID, IsPublished = n.IsPublished, NewsTitle = n.NewsTitle, TagName = t.TagName })
                            .AsQueryable();
                if (!string.IsNullOrWhiteSpace(news))
                {
                    data = data.Where(c => c.NewsTitle.ToLower().Contains(news.ToLower()) || c.TagName.ToLower().Contains(news.ToLower()));
                }

                ListNewsTags = data.OrderBy(x => x.NewsID).Skip(rowNo)
                                .Take(10).ToList();
                newsTagsViewModel.ListNewsTags = ListNewsTags;
                newsTagsViewModel.Pager = new Pager(newsTagsViewModel.TotalRecords, page);
                newsTagsViewModel.Pager.CurrentPage = page;

            }
            Session["search"] = news;
            return PartialView("~/Views/Home/_List.cshtml",newsTagsViewModel);



        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
    }

}