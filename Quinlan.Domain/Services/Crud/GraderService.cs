using System.Collections.Generic;
using System.Linq;

using Quinlan.Data.Services;
using Quinlan.Domain.Models;

namespace Quinlan.Domain.Services
{
    public class GraderService : ICrudService<Grader>
    {
        IDataService<Quinlan.Data.Models.Grader> _graderDataService;

        public GraderService(IDataService<Quinlan.Data.Models.Grader> graderDataService)
        {
            _graderDataService = graderDataService;
        }

        public List<Grader> Get()
        {
            var gradersData = _graderDataService.Select();

            var graders = gradersData
                .Select(x => new Grader
                {
                    Id = x.Id,
                    Identifier = x.Organization.Identifier,
                    Name = x.Organization.Name
                })
                .ToList();

            return graders;
        }
        public Grader Get(int id)
        {
            var graderData = _graderDataService.Select(id);

            if (graderData == null)
            {
                throw new DataNotFoundException("Grader not found.  Invalid id provided.");
            }

            return new Grader
            {
                Id = graderData.Id,
                Identifier = graderData.Organization.Identifier,
                Name = graderData.Organization.Name
            };
        }
        public void Post(Grader grader)
        {
            var graderData = new Quinlan.Data.Models.Grader
            {
                Organization = new Quinlan.Data.Models.Organization
                {
                    Identifier = grader.Identifier, // may need to revisit
                    Name = grader.Name
                }
            };

            _graderDataService.Insert(graderData);
        }
        public void Put(int id, Grader grader)
        {
            var graderData = _graderDataService.Select(id);

            graderData.Organization.Name = grader.Name;

            _graderDataService.Update(id, graderData);
        }
        public void Delete(int id)
        {
            throw new DeleteNotSupportedException();
        }
    }
}
