using RW.Core;

namespace RW.Service
{
    public interface IRobotDirectionService
    {
        RobotDirection GetRobotDirection(string userInput);
        RobotDirection GetNewRobotDirection(RobotDirection direction, char command);
    }
}
