using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class CollectibleStatusCodeService
    {
        private static List<CollectibleStatus> values;
        public static List<CollectibleStatus> Select()
        {
            if (values == null)
            {
                values = new List<CollectibleStatus>() {
                    Available ,
                    MarkedForLot ,
                    Sold
                };
            }
            return values;
        }
        public static CollectibleStatus Select(int id)
        {
            if (values == null)
            {
                values = new List<CollectibleStatus>() {
                    Available ,
                    MarkedForLot ,
                    Sold
                };
            }
            return values.Single(x => x.Id == id);
        }
        static private CollectibleStatus available;
        static private CollectibleStatus markedForLot;
        static private CollectibleStatus sold;

        static public CollectibleStatus Available { get { return available ?? (available = new CollectibleStatus { Id = 1, Name = "Available" }); } }
        static public CollectibleStatus MarkedForLot { get { return markedForLot ?? (markedForLot = new CollectibleStatus { Id = 2, Name = "Marked For Lot" }); } }
        static public CollectibleStatus Sold { get { return sold ?? (sold = new CollectibleStatus { Id = 3, Name = "Sold" }); } }
    }
}
