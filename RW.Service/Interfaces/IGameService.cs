using RW.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Service
{
    public interface IGameService
    {
        Robot CreateRobot(string userInput);
        Robot TriggertRobotMovement(string userInput, Robot robot);
        Arena CreateArena(string userInput);
    }
}
