using System.Collections.Generic;

namespace Quinlan.MVC.Models
{
    public class Home
    {
        public string Title { get; set; }
        public string Header { get; set; }
        public string WelcomeMessage { get; set; }
        public bool IsSeeded { get; set; }
        public int FiguresId { get; set; }
        public int MagazinesId { get; set; }
        public int GolfId { get; set; }
        public int CFLId { get; set; }

        public List<ProductListItemViewModel> SingleCardProducts { get; set; }
        public List<ProductListItemViewModel> CardLotProducts { get; set; }
        public List<ProductListItemViewModel> CollectionProducts { get; set; }
    }
}
