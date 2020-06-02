
using Quinlan.MVC.Models;
using Quinlan.Domain.Models;
using Quinlan.Domain.Services;
using System;
using System.Collections.Generic;

namespace Quinlan.MVC.Services
{
    public class CardViewService : IViewService<CardView>
    {
        ICrudService<Card> _cardService;
        public CardViewService(ICrudService<Card> cardService)
        {
            _cardService = cardService;
        }
        public CardView Build(int id)
        {
            try
            {
                var card = _cardService.Get(id);

                var attributes = new List<string>();

                if (card.RCFlag) attributes.Add("Rookie Card");
                if (card.SPFlag) attributes.Add("Single Print");
                if (card.AUFlag) attributes.Add("Autographed");
                if (card.PatchFlag) attributes.Add("Relic");
                if (card.Person != null && card.Person.HOFFlag) attributes.Add("Hall of Fame Player");

                if (attributes.Count == 0) attributes.Add("None");

                var vm = new CardView
                {
                    Id = card.Id ,
                    DisplayName = card.ToString(),
                    CardNumber = card.CardNumber,
                    Company = card.SetName,
                    PersonName = card.Person == null ? "" : card.Person.ToString(),
                    PersonId = card.Person == null ? 0 : card.Person.Id,
                    TeamName = card.Team == null ? "" : card.Team.ToString(),
                    FormattedValue = card.Value.ToString(),
                    FormattedCost = card.Cost.ToString(),
                    Year = card.Year,
                    TeamId = card.Team == null ? 0 : card.Team.Id ,
                    SportName = card.Sport == null ? "" : card.Sport.Name,
                    LeagueName = card.League == null ? "" : card.League.Name,
                    Attributes = attributes ,
                    CardType = card.CardType == null ? "" : card.CardType.Name ,
                    Grade = card.Grade == null ? "[Not Graded]" : card.Grade.Name , 
                    ImportBeckett = card.ImportCard.Beckett.ToString() ,
                    ImportCardNumber = card.ImportCard.CardNumber,
                    ImportCompany = card.ImportCard.Company,
                    ImportDescription = card.ImportCard.Description,
                    ImportFirstName = card.ImportCard.FirstName,
                    ImportGrade = card.ImportCard.Grade,
                    ImportInStock = card.ImportCard.InStock,
                    ImportLastName = card.ImportCard.LastName,
                    ImportLeague = card.ImportCard.League,
                    ImportNotableFlag = card.ImportCard.NotableFlag.ToString() ,
                    ImportSport = card.ImportCard.Sport,
                    ImportSubjectType = card.ImportCard.SubjectType,
                    ImportTeam = card.ImportCard.Team,
                    ImportType = card.ImportCard.Type,
                    ImportValue = card.ImportCard.Value.ToString() ,
                    ImportX1 = card.ImportCard.X1,
                    ImportX2 = card.ImportCard.X2,
                    ImportX3 = card.ImportCard.X3,
                    ImportYear = card.ImportCard.Year.ToString()
                };

                return vm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
