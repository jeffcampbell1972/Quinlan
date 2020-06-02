using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quinlan.Data.Services
{

    public class DatabaseService
    {
        QdbContext _qDb;
        public DatabaseService(QdbContext qDb)
        {
            _qDb = qDb;
        }
        public bool IsSeeded()
        {
            int numCollectibles = _qDb.Collectibles.Count();

            return numCollectibles > 0;
        }
    }
}
