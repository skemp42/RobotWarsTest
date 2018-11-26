using RW.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RW.Service
{
    public class RobotInstructionService : IRobotInstructionService
    {
        
        private Robot PlayerRobot;
        private readonly IRobotDirectionService DirectionService;

        public RobotInstructionService(IRobotDirectionService directionService)
        {
            DirectionService = directionService;
        }

        public IRobotInstructionService SetRobot(Robot robot)
        {
            PlayerRobot = robot;
            return this;
        }

        public void TriggerMovement(string userInput)
        {
            if (PlayerRobot == null)
            {
                throw new ArgumentNullException("Robot not set in Instruction service.");
            }

            FollowInstructions(userInput.ToCharArray());
        }

        private void FollowInstructions(char[] instructions)
        {
            foreach (var instruction in instructions)
            {
                if (instruction == 'L' || instruction == 'R')
                {
                    PlayerRobot.Direction = DirectionService.GetNewRobotDirection(PlayerRobot.Direction, instruction);
                }
                else if (instruction == 'M')
                {
                    MoveRobotsPosition();
                }
            }
        }

        private void MoveRobotsPosition()
        {
            switch (PlayerRobot.Direction)
            {
                case RobotDirection.N:
                    PlayerRobot.MoveNorth();
                    break;
                case RobotDirection.S:
                    PlayerRobot.MoveSouth();
                    break;
                case RobotDirection.E:
                    PlayerRobot.MoveEast();
                    break;
                case RobotDirection.W:
                    PlayerRobot.MoveWest();
                    break;
                default:
                    throw new InvalidOperationException("Something went wrong. Player direction not set up correctly.");
            }
        }
    }
}