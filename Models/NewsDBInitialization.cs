using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace NewsTagsApp.Models
{
    public class NewsDBInitialization : DropCreateDatabaseAlways<NewsDbContext>         // drops db on the first run
    {
        public override void InitializeDatabase(NewsDbContext context)  // making sure that we don't have any issue in dropping the db
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        //This creates data and push into the parent and child tables. Also, relates each news with at least two random tags.
        protected override void Seed(NewsDbContext newsDbContext)
        {
            newsDbContext.Configuration.AutoDetectChangesEnabled = false;

            int seedValue = 1;
            int limitValue = 20000;                     // to create 20,000 news records

            IList<News> NewsList = new List<News>();

            while (seedValue <= limitValue)
            {

                NewsList.Add(new News() { NewsID= seedValue, NewsTitle = "News" + seedValue.ToString(), IsPublished = true });
                seedValue++;
            }

            newsDbContext.News.AddRange(NewsList);

            IList<Tags> TagsList = new List<Tags>();                //fixed tags

            TagsList.Add(new Tags() {TagID=1,  TagName = "EID Holidays" });
            TagsList.Add(new Tags() {TagID=2,  TagName = "National Day" });
            TagsList.Add(new Tags() {TagID=3,  TagName = "New Year" });
            TagsList.Add(new Tags() {TagID=4,  TagName = "EXPO Delayed" });
            TagsList.Add(new Tags() {TagID=5,  TagName = "COVID Vaccines" });
            TagsList.Add(new Tags() {TagID=6,  TagName = "Flights resumed" });

            newsDbContext.Tags.AddRange(TagsList);

            //newsDbContext.NewsTags.AddOrUpdate(nt => nt.Id,
            //    new NewsTags
            //    {
            //        News = new News() { NewsTitle = "News-" + seedValue.ToString(), IsPublished = true },
            //        Tags = new Tags() { TagName = "Internationl Women Day" }
            //    }

            IList<NewsTags> NewsTagsList = new List<NewsTags>();

    

            foreach (var n in NewsList)                 //associating each news to atleast 2 random tags
            {
                int TagsCount = 2;

                foreach (var t in TagsList.OrderBy(x => Guid.NewGuid()).Take(TagsCount))            //GUID to take a random index outta list
                {
                    NewsTagsList.Add(new NewsTags() { NewsID = n.NewsID, TagID = t.TagID });
                    
                }
            }

           
            newsDbContext.NewsTags.AddRange(NewsTagsList);

            newsDbContext.ChangeTracker.DetectChanges();

            base.Seed(newsDbContext);
        }
    }
}