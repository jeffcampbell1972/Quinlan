using System;
using System.Collections.Generic;
using System.Linq;

using Quinlan.API.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;

namespace Quinlan.API.Services
{
    public class CollegesApiService : IApiService<CollegeDTO>
    {
        ICrudService<College> _collegeService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public CollegesApiService(ICrudService<College> collegeService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _collegeService = collegeService;
            _cardSearchService = cardSearchService;
        }
        public List<CollegeDTO> Get()
        {
            var colleges = _collegeService.Get();

            var collegeDTOs = colleges.Select(x => new CollegeDTO
            {
                 Id = x.Id ,
                 Name = x.Name ,
                 Cards = new List<CardDTO>()
            })
            .ToList();

            return collegeDTOs;
        }
        public CollegeDTO Get(int id)
        {
            var college = _collegeService.Get(id);

            var cardFilterOptions = new CardSearchFilterOptions
            {
                CollegeId = id
            };

            var cardSearch = _cardSearchService.Get(cardFilterOptions);

            var cardDTOs = cardSearch.Cards.Select(x => new CardDTO
            {
                Id = x.Id ,
                CompanyName = x.SetName ,
                CardNumber = x.CardNumber.ToString() ,
                Year = x.Year.ToString() ,
                RC = x.RCFlag ? "RC" : "" ,
                PersonName = x.Person == null ? "" : x.Person.ToString() ,
                PersonId = x.Person == null ? 0 : x.Person.Id ,
                TeamName = x.Team == null ? "" : x.Team.ToString() ,
                TeamId = x.Team == null ? 0 : x.Team.Id
            })
            .ToList();

            var collegeDTO = new CollegeDTO
            {
                Id = college.Id ,
                Name = college.Name ,
                Cards = cardDTOs
            };

            return collegeDTO;
        }
    
        public void Post(CollegeDTO collegeDTO)
        {
            throw new Exception();
        }
        public void Put(int id, CollegeDTO collegeDTO)
        {
            throw new Exception();
        }
        public void Delete(int id)
        {
            throw new Exception();
        }
    }
}
