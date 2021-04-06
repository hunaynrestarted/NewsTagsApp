using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NewsTagsApp.Models
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext() : base("NewsDbContext")
        {
            Database.SetInitializer(new NewsDBInitialization());
        }
        public DbSet<News> News { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<NewsTags> NewsTags { get; set; }

        
    }
}