using System;
using System.Collections.Generic;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class CardService : ICrudService<Card>
    {
        IDataService<Quinlan.Data.Models.Collectible> _collectibleDataService;
        public CardService(IDataService<Quinlan.Data.Models.Collectible> collectibleDataService)
        {
            _collectibleDataService = collectibleDataService;
        }

        public List<Card> Get()
        {
            throw new GetNotSupportedException();
        }
        public Card Get(int id)
        {
            var collectibleData = _collectibleDataService.Select(id);

            if (collectibleData == null)
            {
                throw new DataNotFoundException("Card not found.  Invalid id provided.");
            }
            if (collectibleData.CollectibleTypeId != CollectibleTypeCodeService.Card.Id)
            {
                throw new Exception("Id provided does not belong to a Card.");
            }

            var card = new Card
            { 
                Id = collectibleData.Id, 
                Year = collectibleData.Year ,
                Cost = collectibleData.Cost ,
                Value = collectibleData.Value ,
                RCFlag = collectibleData.RCFlag,
                SPFlag = collectibleData.SPFlag ,
                AUFlag = collectibleData.AUFlag,
                PatchFlag = collectibleData.PatchFlag,
                GradedFlag = collectibleData.GradedFlag,
                NotableFlag = collectibleData.RCFlag,
                SetName = collectibleData.Set.Name ,
                Condition = collectibleData.GradedFlag ? "" : collectibleData.Condition ,
                CardNumber = collectibleData.CardNumber,
                Sport = collectibleData.Sport == null ? null : new Sport
                {
                    Id = collectibleData.Sport.Id ,
                    Identifier = collectibleData.Sport.Identifier ,
                    Name = collectibleData.Sport.Name
                } ,
                League = collectibleData.League == null ? null : new League
                {
                    Id = collectibleData.League.Id,
                    Identifier = collectibleData.League.Identifier,
                    Name = collectibleData.Sport.Name
                },
                CardType = collectibleData.CardType == null ? null : new CardType
                {
                    Id = collectibleData.CardType.Id,
                    Identifier = collectibleData.CardType.Identifier,
                    Name = collectibleData.CardType.Name
                },
                Person = collectibleData.Person == null ? null : new Person
                {
                    Id = collectibleData.Person.Id,
                    Identifier = collectibleData.Person.Identifier,
                    FirstName = collectibleData.Person.FirstName,
                    LastName = collectibleData.Person.LastName,
                    MiddleName = collectibleData.Person.MiddleName,
                    Suffix = collectibleData.Person.Suffix,
                    HOFFlag = collectibleData.Person.HOFFlag == true ? true : false
                },
                Team = collectibleData.Team == null ? null : new Team
                {
                    Id = collectibleData.Team.Id,
                    Identifier = collectibleData.Team.Identifier,
                    City = collectibleData.Team.City,
                    Nickname = collectibleData.Team.Nickname
                },
                Grade = collectibleData.Grade == null ? null : new Grade
                {
                    Id = collectibleData.Grade.Id,
                    Identifier = collectibleData.Grade.Identifier,
                    Name = collectibleData.Grade.Name
                },
                Container = collectibleData.Container == null ? null : new Container
                {
                    Id = collectibleData.Container.Id,
                    Identifier = collectibleData.Container.Identifier,
                    Name = collectibleData.Container.Name
                } ,
                ImportCard = collectibleData.ImportCollectible == null ? null : new ImportCard
                {
                    Id = collectibleData.ImportCollectible.Id,
                    Beckett = collectibleData.ImportCollectible.Beckett,
                    CardNumber = collectibleData.ImportCollectible.CardNumber,
                    Company = collectibleData.ImportCollectible.Company,
                    Description = collectibleData.ImportCollectible.Description,
                    FirstName = collectibleData.ImportCollectible.FirstName,
                    Grade = collectibleData.ImportCollectible.Grade ,
                    InStock = collectibleData.ImportCollectible.InStock,
                    LastName = collectibleData.ImportCollectible.LastName,
                    League = collectibleData.ImportCollectible.League,
                    NotableFlag = collectibleData.ImportCollectible.NotableFlag,
                    Sport = collectibleData.ImportCollectible.Sport,
                    SubjectType = collectibleData.ImportCollectible.SubjectType ,
                    Team = collectibleData.ImportCollectible.Team,
                    Type = collectibleData.ImportCollectible.Type ,
                    Value = collectibleData.ImportCollectible.Value ,
                    X1 = collectibleData.ImportCollectible.X1,
                    X2 = collectibleData.ImportCollectible.X2,
                    X3 = collectibleData.ImportCollectible.X3,
                    Year = collectibleData.ImportCollectible.Year
                }
            };

            return card;
        }
        public void Post(Card card)
        {
            var cardData = new Quinlan.Data.Models.Collectible
            {
                CollectibleTypeId = CollectibleTypeCodeService.Card.Id,
                CollectibleStatusId = CollectibleStatusCodeService.Available.Id,
                Identifier = card.Identifier, // need to build this field
                PersonId = card.Person.Id
            };

            _collectibleDataService.Insert(cardData);
        }
        public void Put(int id, Card card)
        {
            var collectibleData = _collectibleDataService.Select(id);

            if (card.Container == null)
                collectibleData.ContainerId = null;
            else
                collectibleData.ContainerId = card.Container.Id;

            //collectibleData.Year = card.Year;
            //collectibleData.CardNumber = card.CardNumber;

            //collectibleData.RCFlag = card.RCFlag;
            //collectibleData.AUFlag = card.AUFlag;
            //collectibleData.PatchFlag = card.PatchFlag;
            //collectibleData.GradedFlag = card.GradedFlag;
            //collectibleData.NotableFlag = card.NotableFlag;
            
            

            _collectibleDataService.Update(id, collectibleData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
