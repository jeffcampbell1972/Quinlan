using System;
using System.Collections.Generic;
using System.Linq;

using Quinlan.API.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;

namespace Quinlan.API.Services
{
    public class SportsApiService : IApiService<SportDTO>
    {
        ICrudService<Sport> _sportService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public SportsApiService(ICrudService<Sport> sportService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _sportService = sportService;
            _cardSearchService = cardSearchService;
        }
        public List<SportDTO> Get()
        {
            var sports = _sportService.Get();

            var sportDTOs = sports.Select(x => new SportDTO
            {
                 Id = x.Id ,
                 Name = x.Name ,
                 Cards = new List<CardDTO>()
            })
            .ToList();

            return sportDTOs;
        }
        public SportDTO Get(int id)
        {
            var sport = _sportService.Get(id);

            var cardFilterOptions = new CardSearchFilterOptions
            {
                SportId = id
            };

            var cardSearch = _cardSearchService.Get(cardFilterOptions);

            var cardDTOs = cardSearch.Cards.Select(x => new CardDTO
            {
                Id = x.Id ,
                CompanyName = x.SetName ,
                CardNumber = x.CardNumber.ToString() ,
                Year = x.Year.ToString() ,
                RC = x.RCFlag ? "RC" : "" ,
                PersonName = x.Person.ToString() ,
                TeamName = x.Team.ToString()
            })
            .ToList();

            var sportDTO = new SportDTO
            {
                Id = sport.Id ,
                Name = sport.Name ,
                Cards = cardDTOs
            };

            return sportDTO;
        }
    
        public void Post(SportDTO sportDTO)
        {
            throw new Exception();
        }
        public void Put(int id, SportDTO sportDTO)
        {
            throw new Exception();
        }
        public void Delete(int id)
        {
            throw new Exception();
        }
    }
}
