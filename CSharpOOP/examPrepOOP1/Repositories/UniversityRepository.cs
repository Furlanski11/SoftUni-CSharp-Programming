using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private ICollection<IUniversity> universities = new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models => universities.ToList().AsReadOnly();

        public void AddModel(IUniversity model)
        {
            universities.Add(model);
        }

        public IUniversity FindById(int id)
        {
            IUniversity uni = universities.FirstOrDefault(x => x.Id == id);
            if (uni == null)
            {
                return null;
            }
            return uni;
        }

        public IUniversity FindByName(string name)
        {
            
            IUniversity uni = universities.FirstOrDefault(x => x.Name == name);
            if (uni == null)
            {
                return null;
            }
            return uni;
        }
    }
}
