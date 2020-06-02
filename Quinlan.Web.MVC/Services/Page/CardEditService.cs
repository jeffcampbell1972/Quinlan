using System.Linq;

using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quinlan.MVC.Services
{
    public class CardEditService : IEditService<CardEdit>
    {
        ICrudService<Card> _cardService;
        public CardEditService(ICrudService<Card> cardService)
        {
            _cardService = cardService;
        }
        public CardEdit Build (int id)
        {
            var card = _cardService.Get(id);
           
            var vm = new CardEdit
            {
                DisplayName = card.ToString() ,
                CardVM = new CardViewModel
                {
                    Id = card.Id ,
                    Identifier = card.Identifier ,
                    Year = card.Year ,
                    Company = card.SetName ,
                    CardNumber = card.CardNumber ,
                    PersonId = card.Person == null ? 0 :  card.Person.Id ,
                    PersonName = card.Person == null ? "" : card.Person.ToString() ,
                    TeamId = card.Team == null ? 0 : card.Team.Id ,
                    TeamName = card.Team == null ? "" : card.Team.ToString()
                }
            };

            return vm;
        }
    }
}
