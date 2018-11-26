using Microsoft.VisualStudio.TestTools.UnitTesting;
using RW.Core;
using RW.Service;

namespace RW.Tests.Services
{
    [TestClass]
    public class GameServiceTests
    {
        private IGameService GameService;


        [TestMethod]
        public void CreateArena_CorrectInput_ExpectCorrectYPosition()
        {
            GameService = new MockupCreator().GetGameService();
            var input = "1 2";
            var expected = 2;
            var actual = GameService.CreateArena(input).YLimit;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateArena_CorrectInput_ExpectCorrectXPosition()
        {
            GameService = new MockupCreator().GetGameService();
            var input = "1 2";
            var expected = 1;
            var actual = GameService.CreateArena(input).XLimit;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateRobot_IncorrectInput_ExpectNull()
        {
            GameService = new MockupCreator().GetGameService();
            var input = "23287382Random";
            var result = GameService.CreateRobot(input);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void CreateRobot_CorrectInput_ExpectCorrectXPosition()
        {
            GameService = new MockupCreator().GetGameService();
            var input = "1 2 N";
            var expected = 1;
            var actual = GameService.CreateRobot(input).XPosition;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateRobot_CorrectInput_ExpectCorrectYPosition()
        {
            GameService = new MockupCreator().GetGameService();
            var input = "1 2 N";
            var expected = 2;
            var actual = GameService.CreateRobot(input).YPosition;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TriggertRobotMovement_CorrectInput_ExpectCorrectYPosition()
        {
            var arena = Arena.Create(5, 5);
            var robot = Robot.Activate(1, 1, RobotDirection.N);

            GameService = new MockupCreator(arena, robot).GetGameService();

            var input = "MMMRMMM";
            var expected = 4;
            var actual = GameService.TriggertRobotMovement(input, robot).YPosition;
            Assert.AreEqual(expected, actual);
        }




    }
}
