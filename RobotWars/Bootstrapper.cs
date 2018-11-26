using RW.Core;
using RW.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotWars
{
    class Bootstrapper
    {
        static SimpleIocContainer Container = new SimpleIocContainer();
        static void RegisterTypes()
        {           
            Container.Register<ICreateArenaValidator, GameValidator>();
            Container.Register<RobotWarService, RobotWarService>();
            Container.Register<IGameValidator, GameValidator>();
            Container.Register<IRobotMovementValidator, GameValidator>();
            Container.Register<IRobotPositionValidator, GameValidator>();
            Container.Register<IRobotDirectionService, RobotDirectionService>();
            Container.Register<IRobotInstructionService, RobotInstructionService>();
            Container.Register<IGameService, GameService>();
        }

        public static void Run()
        {
            RegisterTypes();
            Container.Resolve<RobotWarService>().SetNumberOfRobots(2).StartGame();
        }
    }
}
