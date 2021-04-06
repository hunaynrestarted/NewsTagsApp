using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsTagsApp.Models;
using NewsTagsApp.ViewModels;

namespace NewsTagsApp.BusinessLogic
{
    public class NewsTagsMethods
    {
        public NewsTagsViewModel GetAllNewsTags(int pageNo, int pageSize)
        {

            NewsTagsViewModel newsTagsViewModel = new NewsTagsViewModel();
            List<NewsTagsViewModel> ListNewsTags = new List<NewsTagsViewModel>();
            int rowNo = (pageNo - 1) * pageSize;

            using (NewsDbContext context = new NewsDbContext())
            {
                newsTagsViewModel.TotalRecords = context.News.Count();

                var data = (from nt in context.NewsTags
                            join n in context.News
                            on nt.NewsID equals n.NewsID
                            join t in context.Tags
                            on nt.TagID equals t.TagID
                            select new NewsTagsViewModel { NewsID = n.NewsID, IsPublished = n.IsPublished, NewsTitle = n.NewsTitle, TagName = t.TagName })
                            .ToList();
                                                             
                //mapping the data to viewmodel

                ListNewsTags=data.OrderBy(x => x.NewsID).Skip(rowNo)            // pagination
                                .Take(pageSize).ToList();
                newsTagsViewModel.ListNewsTags = ListNewsTags;

                return newsTagsViewModel;
            }

        }

    }
}