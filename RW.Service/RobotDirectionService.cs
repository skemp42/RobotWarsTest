using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RW.Core;

namespace RW.Service
{
    public class RobotDirectionService : IRobotDirectionService
    {

        /// <summary>
        /// Gets robot direction from user input. Throws exception if no direction found. 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public RobotDirection GetRobotDirection(string userInput)
        {
            userInput = userInput.ToUpper();

            switch (userInput)
            {
                case "N":
                    return RobotDirection.N;
                case "E":
                    return RobotDirection.E;
                case "S":
                    return RobotDirection.S;
                case "W":
                    return RobotDirection.W;
                default:
                    throw new ArgumentException("User input incorrect. Unable to find Robot Direction");
            }
        }

        public RobotDirection GetNewRobotDirection(RobotDirection direction, char command)
        {

            if (command != 'L' && command != 'R') throw new ArgumentException("Command not valid. Use R or L");

            var isLeft = command == 'L';

            switch (direction)
            {
                case RobotDirection.N:
                    return isLeft ? RobotDirection.W : RobotDirection.E;
                case RobotDirection.E:
                    return isLeft ? RobotDirection.N : RobotDirection.S;
                case RobotDirection.S:
                    return isLeft ? RobotDirection.W : RobotDirection.E;
                case RobotDirection.W:
                    return isLeft ? RobotDirection.S : RobotDirection.N;
                default:
                    throw new ArgumentException("Robot Direction not valid.");
            }
        }
    }
}
