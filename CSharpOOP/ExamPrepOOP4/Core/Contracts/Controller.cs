using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace PlanetWars.Core.Contracts
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        //private UnitRepository units;
       // private WeaponRepository weapons;
        
        public Controller()
        {
            planets = new PlanetRepository();
            //units = new UnitRepository();
            //weapons = new WeaponRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            
            if(planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if( unitTypeName != nameof(AnonymousImpactUnit) &&
                unitTypeName != nameof(StormTroopers) &&
                unitTypeName != nameof(SpaceForces))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if(planet.Army.FirstOrDefault(u => u.GetType().Name == unitTypeName)  != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded,unitTypeName, planetName));
            }
            
            switch (unitTypeName)
            {

                case nameof(StormTroopers):
                    IMilitaryUnit stUnit = new StormTroopers();
                    planet.AddUnit(stUnit);
                    planet.Spend(stUnit.Cost);
                    break;
                case nameof(SpaceForces):
                    IMilitaryUnit sfUnit = new SpaceForces();
                    planet.AddUnit(sfUnit);
                    planet.Spend(sfUnit.Cost);
                    break;
                case nameof(AnonymousImpactUnit):
                    IMilitaryUnit aiUnit = new AnonymousImpactUnit();
                    planet.AddUnit(aiUnit);
                    planet.Spend(aiUnit.Cost);
                    break;
            }
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
            
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            

            if(planet.Weapons.FirstOrDefault(w => w.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(SpaceMissiles) &&
                weaponTypeName != nameof(NuclearWeapon))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }
            
            switch (weaponTypeName)
            {

                case nameof(BioChemicalWeapon):
                    IWeapon bioChemWeapon = new BioChemicalWeapon(destructionLevel);
                    planet.AddWeapon(bioChemWeapon);
                    planet.Spend(bioChemWeapon.Price);
                    break;
                case nameof(NuclearWeapon):
                    IWeapon nucWeapon = new NuclearWeapon(destructionLevel);
                    planet.AddWeapon(nucWeapon);
                    planet.Spend(nucWeapon.Price);
                    break;
                case nameof(SpaceMissiles):
                    IWeapon spaceMissiles = new SpaceMissiles(destructionLevel);
                    planet.AddWeapon(spaceMissiles);
                    planet.Spend(spaceMissiles.Price);
                    break;
            }
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);
            if(planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models)
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            bool firstPlanetHasNuclearWeapon = false;
            bool secondPlanetHasNuclearWeapon = false;
            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                FirstPlanetWins();
                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
            }

            if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                SecondPlanetWins();
                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }

            if(firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                foreach (var weapon in firstPlanet.Weapons)
                {
                    if(weapon.GetType().Name == nameof(NuclearWeapon))
                    {
                        firstPlanetHasNuclearWeapon = true;
                    }
                }
                foreach (var weapon in secondPlanet.Weapons)
                {
                    if (weapon.GetType().Name == nameof(NuclearWeapon))
                    {
                        secondPlanetHasNuclearWeapon = true;
                    }
                }
                if(firstPlanetHasNuclearWeapon == true && secondPlanetHasNuclearWeapon == false)
                {
                    FirstPlanetWins();
                    return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                if (firstPlanetHasNuclearWeapon == false && secondPlanetHasNuclearWeapon == true)
                {
                    SecondPlanetWins();
                    return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
                
                if(firstPlanetHasNuclearWeapon == true && secondPlanetHasNuclearWeapon == true)
                {
                    firstPlanet.Spend(firstPlanet.Budget/2);
                    secondPlanet.Spend(secondPlanet.Budget/2);
                    return OutputMessages.NoWinner;
                }
                if (firstPlanetHasNuclearWeapon == false && secondPlanetHasNuclearWeapon == false)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }
            }
            
            void FirstPlanetWins()
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                double forcesCosts = 0;
                foreach (var force in secondPlanet.Army)
                {
                    forcesCosts += force.Cost;
                }
                firstPlanet.Profit(forcesCosts);

                double weaponPrices = 0;
                foreach (var weapon in secondPlanet.Weapons)
                {
                    weaponPrices += weapon.Price;
                }
                firstPlanet.Profit(weaponPrices);
                planets.RemoveItem(planetTwo);
            }
            void SecondPlanetWins()
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                double forcesCosts = 0;
                foreach (var force in firstPlanet.Army)
                {
                    forcesCosts += force.Cost;
                }
                secondPlanet.Profit(forcesCosts);

                double weaponPrices = 0;
                foreach (var weapon in firstPlanet.Weapons)
                {
                    weaponPrices += weapon.Price;
                }
                secondPlanet.Profit(weaponPrices);
                planets.RemoveItem(planetOne);
            }
            return "Somethings Wrong!!!";
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            
            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.TrainArmy();
            planet.Spend(1.25);
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
