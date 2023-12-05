using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private ICollection<IStudent> students = new List<IStudent>();
        public IReadOnlyCollection<IStudent> Models => students.ToList().AsReadOnly();

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)
        {
            IStudent student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(' ');
            IStudent student = students.FirstOrDefault(x => x.FirstName == names[0] && x.LastName == names[1]);
            if (student == null)
            {
                return null;
            }
            return student;
        }
    }
}
