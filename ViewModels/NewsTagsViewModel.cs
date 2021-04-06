using NewsTagsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsTagsApp.ViewModels
{

    public class NewsTagsViewModel
    {

        public List<NewsTagsViewModel> ListNewsTags { get; set; }
        public Pager Pager { get; set; }
        public int TotalRecords { get; set; }

        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public bool IsPublished { get; set; }
        public string TagName { get; set; }
    }
}