using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordReview
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual WordEntity Word { get; set; }
    }
}