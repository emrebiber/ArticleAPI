using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleAPI.DAL.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
