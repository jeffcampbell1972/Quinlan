using System;
using System.Collections.Generic;
using System.Linq;

using Quinlan.API.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;

namespace Quinlan.API.Services
{
    public class TeamsApiService : IApiService<TeamDTO>
    {
        ICrudService<Team> _teamService;
        ICollectibleSearchService<CardSearch, CardSearchFilterOptions> _cardSearchService;
        public TeamsApiService(ICrudService<Team> teamService, ICollectibleSearchService<CardSearch, CardSearchFilterOptions> cardSearchService)
        {
            _teamService = teamService;
            _cardSearchService = cardSearchService;
        }
        public List<TeamDTO> Get()
        {
            var teams = _teamService.Get();

            var teamDTOs = teams.Select(x => new TeamDTO
            {
                 Id = x.Id ,
                 Name = x.Name ,
                 Cards = new List<CardDTO>()
            })
            .ToList();

            return teamDTOs;
        }
        public TeamDTO Get(int id)
        {
            var team = _teamService.Get(id);

            var cardFilterOptions = new CardSearchFilterOptions
            {
                TeamId = id
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

            var teamDTO = new TeamDTO
            {
                Id = team.Id ,
                Name = team.Name ,
                Cards = cardDTOs
            };

            return teamDTO;
        }
    
        public void Post(TeamDTO teamDTO)
        {
            throw new Exception();
        }
        public void Put(int id, TeamDTO teamDTO)
        {
            throw new Exception();
        }
        public void Delete(int id)
        {
            throw new Exception();
        }
    }
}
