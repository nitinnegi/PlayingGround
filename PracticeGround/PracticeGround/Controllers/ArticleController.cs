using PracticeGround.Models;
using PracticeGround.Service;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeGround.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ISearchService _searchService;
        
        public ArticleController()
        {
            _searchService = new SitecoreSearchService();
            
        }
        // GET: Article
        public ActionResult DisplayArticle()
        {
            Item currentitem;
            ArticleModel model = new ArticleModel();
            var dataSource = RenderingContext.Current.Rendering.DataSource;
            
            if (!string.IsNullOrEmpty(dataSource))
            {
                currentitem = Sitecore.Context.Database.GetItem(dataSource);
            }
            else
            {
                currentitem = Sitecore.Context.Item;
            }
            

            if (currentitem != null)
            {
                
                model.Author = currentitem.Fields[Templates.ArticleTempalte.Author].ToString();
                model.Body = currentitem.Fields[Templates.ArticleTempalte.Body].ToString();
                model.Date = currentitem.Fields[Templates.ArticleTempalte.Date].ToString();
                model.Topic = currentitem.Fields[Templates.ArticleTempalte.Topic].ToString();
            }
            return View(model);
        }

        public ViewResult ArticleSearch()
        {
            return View(new ArticleSearchViewModel());
        }
        [HttpPost]
        public PartialViewResult SubmitSearch(ArticleSearchViewModel viewModel)
        {
            var resultsViewModel = new SearchResultsViewModel();
            var results = _searchService.SearchArticles(viewModel.SearchTerm,"");
            foreach (var result in results)
            {
                resultsViewModel.Results.Add(new SearchResultViewModel()
                {
                    Id = result.ItemId.ToString(),
                    Title = result.Title,
                    Url = result.Url
                });
            }
            return PartialView("~/Views/Search/_SearchResults.cshtml", resultsViewModel);
        }
    }
}