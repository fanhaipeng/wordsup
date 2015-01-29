using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordEntity
    {
        [Key]
        public int WordId { get; set; }

        public string Word { get; set; }

        public int Frequency { get; set; }
    }
}