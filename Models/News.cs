﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsTagsApp.Models
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public Boolean IsPublished { get; set; }

        //public virtual ICollection<Tags> Tags { get; set; }
    }
}