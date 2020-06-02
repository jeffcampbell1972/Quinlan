using System;
using System.Collections.Generic;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class MagazineService : ICrudService<Magazine>
    {
        IDataService<Quinlan.Data.Models.Collectible> _collectibleDataService;
        public MagazineService(IDataService<Quinlan.Data.Models.Collectible> collectibleDataService)
        {
            _collectibleDataService = collectibleDataService;
        }

        public List<Magazine> Get()
        {
            throw new GetNotSupportedException();
        }
        public Magazine Get(int id)
        {
            var magazineData = _collectibleDataService.Select(id);

            if (magazineData == null)
            {
                throw new ItemNotFoundException("MagazineService not found.  Invalid id provided.");
            }
            if (magazineData.CollectibleTypeId != CollectibleTypeCodeService.Magazine.Id)
            {
                throw new Exception("Id provided does not belong to a Magazatin.");
            }

            return new Magazine
            { 
                Id = magazineData.Id,
                Identifier = magazineData.Identifier ,
                PublisherName = magazineData.Set.Name ,
                PersonName = magazineData.Person.ToString() ,
                TeamName = string.Format("{0} {1}", magazineData.Team.City, magazineData.Team.Nickname) ,
                Description = magazineData.ImportCollectible.Description
            };
        }
        public void Post(Magazine magazine)
        {
            throw new PostNotSupportedException();
        }
        public void Put(int id, Magazine magazine)
        {
            throw new PutNotSupportedException();
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
