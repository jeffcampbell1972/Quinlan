using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Models;

namespace Quinlan.Data.Services
{
    public static class SportCodeService
    {
        private static List<Sport> values;
        public static List<Sport> Select()
        {
            if (values == null)
            {
                values = new List<Sport>() {
                    Baseball ,
                    Basketball ,
                    Football ,
                    Hockey ,
                    Golf
                };
            }

            return values;
        }
        public static Sport Select(int id)
        {
            if (values == null)
            {
                values = new List<Sport>() {
                    Baseball ,
                    Basketball ,
                    Football ,
                    Hockey ,
                    Golf
                };
            }

            return values.Single(x => x.Id == id);
        }

        static private Sport baseball;
        static private Sport basketball;
        static private Sport football;
        static private Sport hockey;
        static private Sport golf;

        static public Sport Baseball { get { return baseball ?? (baseball = new Sport { Id = 1, Identifier = "BS", Name = "Baseball" }); } }
        static public Sport Basketball { get { return basketball ?? (basketball = new Sport { Id = 2, Identifier = "BK", Name = "Basketball" }); } }
        static public Sport Football { get { return football ?? (football = new Sport { Id = 3, Identifier = "FB", Name = "Football" }); } }
        static public Sport Hockey { get { return hockey ?? (hockey = new Sport { Id = 4, Identifier = "HO", Name = "Hockey" }); } }
        static public Sport Golf { get { return golf ?? (golf = new Sport { Id = 5, Identifier = "GF", Name = "Golf" }); } }
    }
}
