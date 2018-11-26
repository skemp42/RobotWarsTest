using RW.Core;

namespace RW.Service
{
    public interface IRobotInstructionService
    {
        void TriggerMovement(string userInput);
        IRobotInstructionService SetRobot(Robot robot);
    }
}
