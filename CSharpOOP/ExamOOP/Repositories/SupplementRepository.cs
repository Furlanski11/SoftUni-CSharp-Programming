﻿using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;
        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }
        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
            return supplement;
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements;
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.GetType().Name == typeName);
            if(supplement != null)
            {
                supplements.Remove(supplement);
                return true;
            }
            return false;
        }
    }
}
