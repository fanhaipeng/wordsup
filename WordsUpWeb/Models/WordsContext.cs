using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordsContext : DbContext
    {
        public IList<WordEntity> WordsList { get; set; }
    }
}