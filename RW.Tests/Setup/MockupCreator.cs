using RW.Core;
using RW.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Tests
{
    public class MockupCreator
    {
        private Arena Arena;
        private Robot Robot;

        public MockupCreator(Arena arena, Robot robot)
        {
            Arena = arena;
            Robot = robot;
            SetupArenaAndRobot();
        }

        public MockupCreator()
        {
        }

        private void SetupArenaAndRobot()
        {
            Arena.AddRobot(Robot);
        }

        public IGameService GetGameService()
        {
            return new GameService(CreateRobotDirectionService(), GetGameValidator(), CreateRobotInstructionService());
        }

        public IRobotDirectionService CreateRobotDirectionService()
        {
            return new RobotDirectionService();
        }

        public IRobotInstructionService CreateRobotInstructionService()
        {
            return new RobotInstructionService(CreateRobotDirectionService()).SetRobot(Robot);
        }

        

        public IGameValidator GetGameValidator()
        {
            return new GameValidator();
        }

    }
}
