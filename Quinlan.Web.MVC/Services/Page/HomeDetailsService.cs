using System.Collections.Generic;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System.Linq;

namespace Quinlan.MVC.Services
{
    public class HomeDetailsService : IHomeService<Summary>
    {
        ISummaryService<DataSummary> _summaryService;

        public HomeDetailsService(ISummaryService<DataSummary> summaryService)
        {
            _summaryService = summaryService;
        }
        public Summary Build()
        {
            var dataSummary = _summaryService.Get();

            var vm = new Summary
            {
                DbTotals = new SubTotalViewModel
                {
                    Description = dataSummary.DbTotals.Description,
                    NumItems = dataSummary.DbTotals.NumItems,
                    TotalCost = dataSummary.DbTotals.TotalCost,
                    TotalValue = dataSummary.DbTotals.TotalValue
                },
                BaseballCardSubTotals = dataSummary.BaseballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList() ,
                BasketballCardSubTotals = dataSummary.BasketballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
                FootballCardSubTotals = dataSummary.FootballCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
                HockeyCardSubTotals = dataSummary.HockeyCardSubTotals.Select(x => new SubTotalViewModel
                {
                    Description = x.Description,
                    NumItems = x.NumItems,
                    TotalCost = x.TotalCost,
                    TotalValue = x.TotalValue
                })
                .ToList(),
            };

            return vm;
        }
     }
}
