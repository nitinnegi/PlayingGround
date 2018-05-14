using System.Collections.Generic;
using PracticeGround.Models;
using Sitecore.ContentSearch.SearchTypes;


namespace PracticeGround.Service
{
    public interface ISearchService
    {
        IEnumerable<ArticleSearchResult> SearchArticles(string searchTerm,string searchStartPath);
    }
}