using Microsoft.VisualStudio.TestTools.UnitTesting;
using RW.Core;
using RW.Service;

namespace RW.Tests.Services
{
    [TestClass]
    public class RobotInstructionServiceTests
    {
        private IRobotInstructionService InstructionService;


        [TestMethod]
        public void TriggerMovement_correctInput_CorrectYPosition()
        {
            // Arena size 5, 5
            // Robot Position 1 1 N
            // MMRMM = y + 2, x + 2
            // Expected Y position 3 

            var robot = Robot.Activate(1, 1, RobotDirection.N);
            var arena = Arena.Create(5, 5);
            var input = "MMRMM";

            InstructionService = new MockupCreator(arena, robot).CreateRobotInstructionService();

            var expected = 3;
            InstructionService.TriggerMovement(input);
            Assert.AreEqual(expected, robot.YPosition);
        }

        [TestMethod]
        public void TriggerMovement_correctInput_CorrectXPosition()
        {
            // Arena size 5, 5
            // Robot Position 1 1 N
            // MMRMMM = y + 2, x + 3
            // Expected X position 4 

            var robot = Robot.Activate(1, 1, RobotDirection.N);
            var arena = Arena.Create(5, 5);
            var input = "MMRMMM";

            InstructionService = new MockupCreator(arena, robot).CreateRobotInstructionService();

            var expected = 4;
            InstructionService.TriggerMovement(input);
            Assert.AreEqual(expected, robot.XPosition);
        }

        [TestMethod]
        public void TriggerMovement_correctInputHitWall_XNotHigherThanArena()
        {
            // Arena size 5, 5
            // Robot Position 1 1 N
            // MMRMMMMMMMMMMMMM
            // Expected X position 5  

            var robot = Robot.Activate(1, 1, RobotDirection.N);
            var arena = Arena.Create(5, 5);
            var input = "MMRMMMMMMMMMMMMM";

            InstructionService = new MockupCreator(arena, robot).CreateRobotInstructionService();

            var expected = arena.XLimit;
            InstructionService.TriggerMovement(input);
            Assert.AreEqual(expected, robot.XPosition);
        }

        [TestMethod]
        public void TriggerMovement_correctInputHitWall_YNotHigherThanArena()
        {
            // Arena size 5, 5
            // Robot Position 1 1 N
            // MMMMMMMMMMMMRMMMMMMMMMMMMM
            // Expected X position 5  

            var robot = Robot.Activate(1, 1, RobotDirection.N);
            var arena = Arena.Create(5, 5);
            var input = "MMMMMMMMMMMMMMMMRMMMMMMMMMMMMM";

            InstructionService = new MockupCreator(arena, robot).CreateRobotInstructionService();

            var expected = arena.YLimit;
            InstructionService.TriggerMovement(input);
            Assert.AreEqual(expected, robot.YPosition);
        }

    }
}
