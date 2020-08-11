using System;
using System.Collections.Generic;
using System.Linq;
using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class ContainerService : ICrudService<Container>
    {
        IDataService<Quinlan.Data.Models.Container> _containerDataService;
        public ContainerService(IDataService<Quinlan.Data.Models.Container> containerDataService)
        {
            _containerDataService = containerDataService;
        }

        public List<Container> Get()
        {
            var containersData = _containerDataService.Select();

            var containers = containersData
                .Select(x => new Container
                {
                    Id = x.Id,
                    Identifier = x.Identifier,
                    Name = x.Name 
                })
                .ToList();

            return containers;
        }
        public Container Get(int id)
        {
            var containerData = _containerDataService.Select(id);

            if (containerData == null)
            {
                throw new DataNotFoundException("Container not found.  Invalid id provided.");
            }


            return new Container
            { 
                Id = containerData.Id, 
                Identifier = containerData.Identifier ,
                Name = containerData.Name 
            };
        }
        public void Post(Container container)
        {
            var containerData = new Quinlan.Data.Models.Container
            {
                Identifier = container.Identifier,
                Name = container.Name 
            };

            _containerDataService.Insert(containerData);
        }
        public void Put(int id, Container container)
        {
            var containerData = _containerDataService.Select(id);

            containerData.Name = container.Name;

            _containerDataService.Update(id, containerData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
