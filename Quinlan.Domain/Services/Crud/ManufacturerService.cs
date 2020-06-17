using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class ManufacturerService : ICrudService<Manufacturer>
    {
        IDataService<Quinlan.Data.Models.Manufacturer> _manufacturerDataService;
        
        public ManufacturerService(IDataService<Quinlan.Data.Models.Manufacturer> manufacturerDataService)
        {
            _manufacturerDataService = manufacturerDataService;
        }

        public List<Manufacturer> Get()
        {
            var manufacturersData = _manufacturerDataService.Select();

            var manufacturers = manufacturersData
                .Select(x => new Manufacturer 
                { 
                    Id = x.Id, 
                    Identifier = x.Organization.Identifier ,
                    Name = x.Organization.Name
                })
                .ToList();

            return manufacturers;
        }
        public Manufacturer Get(int id)
        {
            var manufacturerData = _manufacturerDataService.Select(id);

            if (manufacturerData == null)
            {
                throw new ItemNotFoundException("Manufacturer not found.  Invalid id provided.");
            }

            return new Manufacturer 
            { 
                Id = manufacturerData.Id,
                Identifier = manufacturerData.Organization.Identifier,
                Name = manufacturerData.Organization.Name 
            };
        }
        public void Post(Manufacturer manufacturer)
        {
            var manufacturerData = new Quinlan.Data.Models.Manufacturer
            {
                Organization = new Quinlan.Data.Models.Organization
                {
                    Identifier = manufacturer.Identifier, // may need to revisit
                    Name = manufacturer.Name
                }
            };

            _manufacturerDataService.Insert(manufacturerData);
        }
        public void Put(int id, Manufacturer manufacturer)
        {
            var manufacturerData = _manufacturerDataService.Select(id);

            manufacturerData.Organization.Name = manufacturer.Name;

            _manufacturerDataService.Update(id, manufacturerData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
