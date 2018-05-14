
using System.Collections.Generic;
using PracticeGround.Models;
using PracticeGround.Repositories;
namespace PracticeGround.Service
{
    public class SitecoreSearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        public SitecoreSearchService()
        {
            _searchRepository = new SitecoreSearchRepository();
        }

        //public IEnumerable<ArticleSearchResult> SearchArticles(string searchTerm)
        //{
        //    return _searchRepository.Search<ArticleSearchResult>(
        //    q => q.Title.Contains(searchTerm) && q.Path.StartsWith("/sitecore/content/Home"));
        //}

        public IEnumerable<ArticleSearchResult> SearchArticles(string searchTerm, string searchStartPath)
        {
            return _searchRepository.Search<ArticleSearchResult>(
        q => q.Title.Contains(searchTerm) && q.Path.StartsWith("/sitecore/content/Home"));
        }

     
    }
}