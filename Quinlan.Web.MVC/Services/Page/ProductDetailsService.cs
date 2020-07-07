using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;

namespace Quinlan.MVC.Services
{
    public class ProductDetailsService : IDetailsService<ProductDetails>
    {
        ICrudService<Product> _productService;

        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public ProductDetailsService(ICrudService<Product> productService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _productService = productService;
            _cardSearchService = cardSearchService;
        }
        public ProductDetails Build(int id, CardFilterOptionsViewModel filterOptionsVM, bool hasOwnerRights)
        {
            if (filterOptionsVM == null)
            {
                filterOptionsVM = new CardFilterOptionsViewModel
                {
                    ProductId = id ,
                    PersonId = 0 ,
                    CollegeId = 0 ,
                    TeamId = 0 ,
                    LeagueId = 0
                };
            }
            filterOptionsVM.ProductId = id;

            var defaultFilterOptionsVM = new CardFilterOptionsViewModel
            {
                ProductId = id ,
                PersonId = 0,
                CollegeId = 0,
                TeamId = 0 ,
                LeagueId = 0
            };

            var cardFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(filterOptionsVM);
            var defaultFilterOptions = SearchFilterService.BuildCardSearchFilterOptions(defaultFilterOptionsVM);

            var product = _productService.Get(id);

            var cardSearch = _cardSearchService.Get(cardFilterOptions);
            var people = _cardSearchService.GetPeople(defaultFilterOptions);
            var teams = _cardSearchService.GetTeams(defaultFilterOptions);
            var colleges = _cardSearchService.GetColleges(defaultFilterOptions);
            var grades = _cardSearchService.GetGrades(defaultFilterOptions);
            var graders = _cardSearchService.GetGraders(defaultFilterOptions);

            var cards = cardSearch.Cards
               .Select(x => new CardListItemViewModel
               {
                   Id = x.Id,
                   CardNumber = x.CardNumber != null ? x.CardNumber.ToString() : "--" ,
                   FormattedCost = FormatService.FormatDollars(x.Cost) ,
                   FormattedValue = FormatService.FormatDollars(x.Value) ,
                   PersonName = x.Person == null ? "" : x.Person.ToString() ,
                   PersonId = x.Person == null ? 0 : x.Person.Id ,
                   TeamName = x.Team == null ? "" : x.Team.ToString() ,
                   TeamId = x.Team == null ? 0 : x.Team.Id ,
                   Company = x.SetName ,
                   Grade = x.Grade != null ? x.Grade.Name : "" ,
                   GraderName = x.Grade != null ? x.Grade.GraderName : "" ,
                   RC = x.RCFlag ? "RC" : "" ,
                   HOF = x.Person == null ? "" : x.Person.HOFFlag ? " (HOF)" : "" ,
                   Year = x.Year.ToString() ,
                   Attributes = FormatService.BuildAttributes(x)
               })
               .ToList();


            var productDetailsViewModel = new ProductDetails
            {
                Id = product.Id ,
                Identifier = product.Identifier ,
                DisplayName = product.Name ,
                Price = product.Price ,
                HasOwnerRights = false ,  // need to revisit this
                Cards = cards,
                SearchTotalsVM = new SearchTotalsViewModel
                {
                    NumCollectibles = cardSearch.NumCards ,
                    TotalCost = cardSearch.TotalCost,
                    TotalValue = cardSearch.TotalValue
                },
                FilterOptionsVM = new CardSearchViewModel
                {
                    ShowPeopleFilters = "" ,
                    ShowHeismanFilter = product.Name == "Football" ? "" : "hidden",
                    People = MvcService.BuildPeopleSelectList(people, cardFilterOptions.PersonId ?? 0) ,
                    Teams = MvcService.BuildTeamsSelectList(teams, cardFilterOptions.TeamId ?? 0) ,
                    Colleges = MvcService.BuildCollegesSelectList(colleges, cardFilterOptions.CollegeId ?? 0),
                    Graders = MvcService.BuildGradersSelectList(graders, cardFilterOptions.GraderId ?? 0),
                    Grades = MvcService.BuildGradesSelectList(grades, cardFilterOptions.GradeId ?? 0) ,
                    MinValues = MvcService.BuildValuesSelectList(cardFilterOptions.MinValue ?? 0) ,
                    MaxValues = MvcService.BuildValuesSelectList(cardFilterOptions.MaxValue ?? 0)
                }
            };

            return productDetailsViewModel;
        }
    }
}
