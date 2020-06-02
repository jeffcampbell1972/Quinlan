using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Quinlan.Data.Models;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class CollectibleSummaryService : ISummaryService<DataSummary>
    {
        IDataService<Collectible> _collectibleDataService;
        public CollectibleSummaryService(IDataService<Collectible> collectibleDataService)
        {
            _collectibleDataService = collectibleDataService;
        }

        public DataSummary Get()
        {
            var dataSummary = new DataSummary();

            var collectibles = _collectibleDataService.Select();

            dataSummary.DbTotals = BuildSubTotal("All Collectibles", collectibles);

            dataSummary.CollectibleTypeSubTotals.Add(BuildSubTotal("Cards", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id).ToList()));
            dataSummary.CollectibleTypeSubTotals.Add(BuildSubTotal("- RCs", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.RCFlag == true).ToList()));
            dataSummary.CollectibleTypeSubTotals.Add(BuildSubTotal("- Graded", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.GradedFlag == true).ToList()));
            dataSummary.CollectibleTypeSubTotals.Add(BuildSubTotal("Magazines", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Magazine.Id).ToList()));
            dataSummary.CollectibleTypeSubTotals.Add(BuildSubTotal("Figurines", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Figure.Id).ToList()));

            dataSummary.BaseballCardSubTotals.Add(BuildSubTotal("Baseball Cards", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Baseball.Id).ToList()));
            dataSummary.BaseballCardSubTotals.Add(BuildSubTotal("- RCs", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Baseball.Id && x.RCFlag == true).ToList()));
            dataSummary.BaseballCardSubTotals.Add(BuildSubTotal("- Graded", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Baseball.Id && x.GradedFlag == true).ToList()));
            
            dataSummary.BasketballCardSubTotals.Add(BuildSubTotal("Basketball Cards", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Basketball.Id).ToList()));
            dataSummary.BasketballCardSubTotals.Add(BuildSubTotal("- RCs", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Basketball.Id && x.RCFlag == true).ToList()));
            dataSummary.BasketballCardSubTotals.Add(BuildSubTotal("- Graded", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Basketball.Id && x.GradedFlag == true).ToList()));
            
            dataSummary.FootballCardSubTotals.Add(BuildSubTotal("Football Cards", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Football.Id).ToList()));
            dataSummary.FootballCardSubTotals.Add(BuildSubTotal("- RCs", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Football.Id && x.RCFlag == true).ToList()));
            dataSummary.FootballCardSubTotals.Add(BuildSubTotal("- Graded", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Football.Id && x.GradedFlag == true).ToList()));
            
            dataSummary.HockeyCardSubTotals.Add(BuildSubTotal("Hockey Cards", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Hockey.Id).ToList()));
            dataSummary.HockeyCardSubTotals.Add(BuildSubTotal("- RCs", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Hockey.Id && x.RCFlag == true).ToList()));
            dataSummary.HockeyCardSubTotals.Add(BuildSubTotal("- Graded", collectibles.Where(x => x.CollectibleTypeId == CollectibleTypeCodeService.Card.Id && x.SportId == SportCodeService.Hockey.Id && x.GradedFlag == true).ToList()));


            return dataSummary;
        }
        protected SubTotal BuildSubTotal(string description, List<Quinlan.Data.Models.Collectible> query)
        {
            var subTotal = new SubTotal
            {
                Description = description,
                NumItems = query.Count(),
                TotalCost = query.Sum(x => x.Cost ?? 0),
                TotalValue = query.Sum(x => x.Value ?? 0)
            };

            return subTotal;
        }
    }
}
