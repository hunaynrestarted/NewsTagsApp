using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewsTagsApp.Models
{
    public class Tags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagID { get; set; }
        public string TagName { get; set; }

        //public static implicit operator int(Tags v)
        //{
        //    throw new NotImplementedException();
        //}

        ////public virtual ICollection<News> News { get; set; }
    }
}