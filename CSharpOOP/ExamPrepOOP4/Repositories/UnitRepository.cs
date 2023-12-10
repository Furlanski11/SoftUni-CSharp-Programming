﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;
        public UnitRepository()
        {
            units = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            IMilitaryUnit unit = units.FirstOrDefault(u => u.GetType().Name == name);
            return unit;
        }

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = units.FirstOrDefault(u => u.GetType().Name == name);
            if(units.Contains(unit))
            {
                units.Remove(unit);
                return true;
            }
            return false;
        }
    }
}
