using Quinlan.MVC.Models;

namespace Quinlan.MVC.Services
{
    public interface IHomePageService
    {
        public Home Build();
        public Summary BuildSummary();
    }
}
