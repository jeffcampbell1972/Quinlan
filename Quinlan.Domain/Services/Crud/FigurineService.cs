using System;
using System.Collections.Generic;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class FigurineService : ICrudService<Figurine>
    {
        IDataService<Quinlan.Data.Models.Collectible> _collectibleDataService;
        public FigurineService(IDataService<Quinlan.Data.Models.Collectible> collectibleDataService)
        {
            _collectibleDataService = collectibleDataService;
        }

        public List<Figurine> Get()
        {
            throw new GetNotSupportedException();
        }
        public Figurine Get(int id)
        {
            var figurineData = _collectibleDataService.Select(id);

            if (figurineData == null)
            {
                throw new ItemNotFoundException("Figurine not found.  Invalid id provided.");
            }
            if (figurineData.CollectibleTypeId != CollectibleTypeCodeService.Figure.Id)
            {
                throw new Exception("Id provided does not belong to a Figurine.");
            }

            return new Figurine
            { 
                Id = figurineData.Id, 
                Identifier = figurineData.Identifier ,
                CompanyName = figurineData.Set.Name ,
                PersonName = figurineData.Person.ToString() ,
                TeamName = string.Format("{0} {1}", figurineData.Team.City, figurineData.Team.Nickname) ,
                Number = figurineData.CardNumber ,
                Description = figurineData.ImportCollectible.Description
            };
        }
        public void Post(Figurine figurine)
        {
            throw new PostNotSupportedException();
        }
        public void Put(int id, Figurine figurine)
        {
            throw new PutNotSupportedException();
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
