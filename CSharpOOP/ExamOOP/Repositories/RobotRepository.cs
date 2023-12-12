using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;
        public RobotRepository()
        {
            robots = new List<IRobot>();
        }
        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            IRobot robot = robots.FirstOrDefault(r => r.InterfaceStandards.Contains(interfaceStandard));
            return robot;
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots;
        }

        public bool RemoveByName(string typeName)
        {
            IRobot robot = robots.FirstOrDefault(r => r.GetType().Name == typeName);
            if(robot != null)
            {
                robots.Remove(robot);
                return true;
            }
            return false;
        }
    }
}
