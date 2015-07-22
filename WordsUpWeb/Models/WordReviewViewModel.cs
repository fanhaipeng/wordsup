using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WordsUpWeb.Models
{
    public class WordReviewViewModel
    {
        private const int ItemPerPage = 10;
        private int lastPage;

        public WordReviewViewModel(IOrderedQueryable<WordReview> wordSet, int pageId)
        {
            this.Total = wordSet.Count();

            lastPage = Total / ItemPerPage;
            if (Total % ItemPerPage == 0)
            {
                lastPage--;
            }

            if (pageId < 0 || pageId > this.lastPage)
            {
                this.PageId = 0;
            }
            else
            {
                this.PageId = pageId;
            }

            this.InitializeReviewSet(wordSet);
        }

        public IList<WordReview> ReviewSet { get; set; }

        public int Total { get; private set; }

        public int PageId { get; private set; }

        public int? PreviousPageId
        {
            get
            {
                if (PageId == 0)
                {
                    return null;
                }
                else
                {
                    return PageId - 1;
                }
            }
        }

        public int? NextPageId
        {
            get
            {
                if (PageId == this.lastPage)
                {
                    return null;
                }
                else
                {
                    return PageId + 1;
                }
            }
        }

        public static string GetSmashLink(int id)
        {
            return string.Format("/Index/Smash/{0}", id);
        }

        public static string DictionaryLink(string word)
        {
            return string.Format("http://cn.bing.com/dict/{0}", word);
        }

        private void InitializeReviewSet(IOrderedQueryable<WordReview> wordSet)
        {
            var beginIndex = this.PageId * ItemPerPage;
            var endIndex = beginIndex + ItemPerPage;
            if (endIndex >= this.Total)
            {
                endIndex = this.Total - 1;
            }

            this.ReviewSet = wordSet.Skip(beginIndex).Take(endIndex - beginIndex).ToList();
        }
    }
}