using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class ContainerDataService : IDataService<Container>
    {
        QdbContext _qDb;
        public ContainerDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Container> Select()
        {
            var containersData = _qDb.Containers
               .ToList();

            return containersData;
        }
        public Container Select(int id)
        {
            var containerData = _qDb.Containers.SingleOrDefault(x => x.Id == id);

            if (containerData == null)
            {
                throw new InvalidIdException("Id not found in Containers.");
            }

            return containerData;
        }
        public void Insert(Container container)
        {
            _qDb.Containers.Add(container);
            _qDb.SaveChanges();
        }
        public void Update(int id, Container container)
        {
            var containerData = _qDb.Containers.SingleOrDefault(x => x.Id == id);

            if (containerData == null)
            {
                throw new InvalidIdException("Id not found in Containers.");
            }
            containerData = container;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var containerData = _qDb.Containers.SingleOrDefault(x => x.Id == id);

            if (containerData == null)
            {
                throw new InvalidIdException("Id not found in Containers.");
            }

            _qDb.Containers.Remove(containerData);
            _qDb.SaveChanges();
        }
    }
}
