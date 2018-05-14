using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeGround.Models
{
    public class ArticleModel
    {
        public string Topic { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }
        public string Author { get; set; }
    }
}