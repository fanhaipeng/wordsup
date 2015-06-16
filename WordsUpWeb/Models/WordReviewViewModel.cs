using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordReviewViewModel
    {
        public string WordContent { get; set; }

        public int ReviewCount { get; set; }

        public string SmashLink { get; set; }

        public string DictionaryLink { get; set; }
    }
}