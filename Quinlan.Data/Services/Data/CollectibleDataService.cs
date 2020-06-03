using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public class CollectibleDataService : IDataService<Collectible>
    {
        QdbContext _qDb;
        public CollectibleDataService(QdbContext qDb)
        {
            _qDb = qDb;
        }

        public List<Collectible> Select()
        {
            var collectiblesList = _qDb.Collectibles
               .ToList();

            return collectiblesList;
        }
        public Collectible Select(int id)
        {
            var collectibleData = _qDb.Collectibles
                .Include(x => x.Set)
                .Include(x => x.Grade)
                .Include(x => x.Person)
                .Include(x => x.Team)
                .Include(x => x.Sport)
                .Include(x => x.League)
                .Include(x => x.CollectibleType)
                .Include(x => x.CollectibleStatus)
                .Include(x => x.CardType)
                .Include(x => x.ImportCollectible)
                .SingleOrDefault(x => x.Id == id);

            if (collectibleData == null)
            {
                throw new InvalidIdException("Id not found in Collectibles.");
            }

            return collectibleData;
        }
        public void Insert(Collectible collectible)
        {
            _qDb.Collectibles.Add(collectible);
            _qDb.SaveChanges();
        }
        public void Update(int id, Collectible collectible)
        {
            var collectibleData = _qDb.Collectibles.SingleOrDefault(x => x.Id == id);

            if (collectibleData == null)
            {
                throw new InvalidIdException("Id not found in Collectibles.");
            }
            collectibleData = collectible;
            _qDb.SaveChanges();
        }
        public void Delete(int id)
        {
            var collectibleData = _qDb.Collectibles.SingleOrDefault(x => x.Id == id);

            if (collectibleData == null)
            {
                throw new InvalidIdException("Id not found in Collectibles.");
            }
            else if (collectibleData.ImportCollectible != null)
            {
                throw new InvalidDeleteException("Cannot delete imported collectible");
            }


            _qDb.Collectibles.Remove(collectibleData);
            _qDb.SaveChanges();
        }
    }
}
