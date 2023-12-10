using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        private const double weaponPrice = 8.75;
        public SpaceMissiles(int destructionLevel) : base(weaponPrice, destructionLevel)
        {

        }
    }
}
