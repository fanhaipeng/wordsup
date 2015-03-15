using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordReview
    {
        [Key, Column(Order = 0)]
        [ForeignKey("User")]
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Word")]
        public virtual int WordId {get;set;}
        public virtual WordEntity Word { get; set; }

        public int Count { get; set; }
    }
}