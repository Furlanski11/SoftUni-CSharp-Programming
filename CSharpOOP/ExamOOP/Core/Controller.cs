using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplemets;
        private RobotRepository robots;
        public Controller()
        {
            supplemets = new SupplementRepository();
            robots = new RobotRepository();
        }
        public string CreateRobot(string model, string typeName) // works
        {
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            switch (typeName)
            {
                case nameof(DomesticAssistant):
                    IRobot domesticRobot = new DomesticAssistant(model);
                    robots.AddNew(domesticRobot);
                    break;
                case nameof(IndustrialAssistant):
                    IRobot industrialRobot = new IndustrialAssistant(model);
                    robots.AddNew(industrialRobot);
                    break;
            }
            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName) // works
        {
            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }
            switch (typeName)
            {
                case nameof(SpecializedArm):
                    ISupplement specialisedArm = new SpecializedArm();
                    supplemets.AddNew(specialisedArm);
                    break;

                case nameof(LaserRadar):
                    ISupplement laserRadar = new LaserRadar();
                    supplemets.AddNew(laserRadar);
                    break;
            }
            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)//works
        {
            List<IRobot> robotsToWork = robots.Models().Where(r => r.InterfaceStandards.Contains(intefaceStandard)).OrderByDescending(r => r.BatteryLevel).ToList();
            int counter = 0;
            if(robotsToWork.Count == 0)
            {
                return String.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            int sum = robotsToWork.Sum(r => r.BatteryLevel);

            if(sum < totalPowerNeeded)
            {
                return String.Format(OutputMessages.MorePowerNeeded,serviceName, totalPowerNeeded - sum);
            }
            else
            {
                foreach (var robot in robotsToWork)
                {
                    if(robot.BatteryLevel >= totalPowerNeeded)
                    {
                        counter++;
                        robot.ExecuteService(totalPowerNeeded);
                        break;
                    }
                    else
                    {
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;
                    }
                }
            }
            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
        }

        public string Report()//works
        {
            StringBuilder sb = new StringBuilder();
            List<IRobot> robotsReport = robots.Models().OrderByDescending(r => r.BatteryLevel).ThenBy(r => r.BatteryCapacity).ToList();
            foreach (var robot in robotsReport)
            {
                sb.AppendLine(robot.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)//works
        {
            int count = 0;
            List<IRobot> robotsToFeed = robots.Models().Where(r => r.Model == model).Where(r => r.BatteryLevel < r.BatteryCapacity / 2).ToList();
            foreach (var robot in robotsToFeed)
            {
                robot.Eating(minutes);
                count++;
            }
            return String.Format(OutputMessages.RobotsFed, count);
        }

        public string UpgradeRobot(string model, string supplementTypeName) // works
        {
            ISupplement supplement = supplemets.Models().FirstOrDefault(s => s.GetType().Name == supplementTypeName);
            
            int interfaceValue = supplement.InterfaceStandard;
            List<IRobot> uprgadeRobots = robots.Models().Where(r => r.InterfaceStandards.Contains(interfaceValue) == false).Where(r => r.Model == model).ToList();

            if (uprgadeRobots.Count == 0)
            {
                return String.Format(OutputMessages.AllModelsUpgraded, model);
            }
            IRobot robotToUprgade = uprgadeRobots[0];
            robotToUprgade.InstallSupplement(supplement);
            supplemets.RemoveByName(supplementTypeName);
            return String.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }
    }
}



