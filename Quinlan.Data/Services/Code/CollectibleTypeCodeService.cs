using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class CollectibleTypeCodeService
    {
        private static List<CollectibleType> values;
        public static List<CollectibleType> Select()
        {
            if (values == null)
            {
                values = new List<CollectibleType>() {
                    Card ,
                    Figure ,
                    Magazine
                };
            }
            return values;
        }

        public static CollectibleType Select(int id)
        {
            if (values == null)
            {
                values = new List<CollectibleType>() {
                    Card ,
                    Figure ,
                    Magazine
                };
            }
            return values.Single(x => x.Id == id);
        }
        static private CollectibleType card;
        static private CollectibleType figure;
        static private CollectibleType magazine;

        static public CollectibleType Card { get { return card ?? (card = new CollectibleType { Id = 1, Identifier = "C", Name = "Card" }); } }
        static public CollectibleType Figure { get { return figure ?? (figure = new CollectibleType { Id = 2, Identifier = "F", Name = "Figure" }); } }
        static public CollectibleType Magazine { get { return magazine ?? (magazine = new CollectibleType { Id = 3, Identifier = "M", Name = "Magazine" }); } }
    }
}
