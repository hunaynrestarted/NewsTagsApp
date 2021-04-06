using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewsTagsApp.Models
{
    public class NewsTags
    {
        [Key]
        public int Id { get; set; }
        public int NewsID { get; set; }
        public int TagID { get; set; }
        public News News { get; set; }
        public Tags Tags { get; set; }
    }
}