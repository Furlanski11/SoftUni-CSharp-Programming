using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository army;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.Append("--Forces: ");
            if(army.Models.Count > 0)
            {
                sb.AppendLine(string.Join(", ", army.Models));
            }
            else
            {
                sb.AppendLine("No units");
            }
            sb.Append("--Combat equipment: ");
            if(weapons.Models.Count > 0)
            {
                foreach (var item in weapons.Models)
                {
                    sb.Append(string.Join(", ", item));
                }
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("No weapons");
            }
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if(Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var soldier in army.Models)
            {
                soldier.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPower()
        {
            double weaponsDestruction = 0;
            foreach (var weapon in weapons.Models)
            {
                weaponsDestruction += weapon.DestructionLevel;
            }
            double unitsEndurances = 0;
            foreach (var unit in army.Models)
            {
                unitsEndurances += unit.EnduranceLevel;
            }
            double sum = unitsEndurances + weaponsDestruction;
            if(army.FindByName(typeof(AnonymousImpactUnit).ToString()) != null)
            {
                sum += sum * 0.30;
            }
            if(weapons.FindByName(typeof(NuclearWeapon).ToString()) != null)
            {
                sum += sum * 0.45;
            }
            return Math.Round(sum, 3);
        }
    }
}
