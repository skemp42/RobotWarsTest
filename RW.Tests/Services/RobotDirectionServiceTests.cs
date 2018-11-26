using Microsoft.VisualStudio.TestTools.UnitTesting;
using RW.Core;
using RW.Service;
using System;

namespace RW.Tests.Services
{
    [TestClass]
    public class RobotDirectionServiceTests
    {
        private IRobotDirectionService DirectionService = new MockupCreator().CreateRobotDirectionService();

        [TestMethod]
        public void GetRobotDirection_N_NorthDirection()
        {
            var input = "N";
            var expected = RobotDirection.N;
            var actual = DirectionService.GetRobotDirection(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRobotDirection_W_WestDirection()
        {
            var input = "W";
            var expected = RobotDirection.W;
            var actual = DirectionService.GetRobotDirection(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRobotDirection_E_EastDirection()
        {
            var input = "E";
            var expected = RobotDirection.E;
            var actual = DirectionService.GetRobotDirection(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRobotDirection_S_SouthDirection()
        {
            var input = "S";
            var expected = RobotDirection.S;
            var actual = DirectionService.GetRobotDirection(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRobotDirection_WLowercase_WestDirection()
        {
            var input = "w";
            var expected = RobotDirection.W;
            var actual = DirectionService.GetRobotDirection(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "User input incorrect. Unable to find Robot Direction")]
        public void GetRobotDirection_InvalidInput_ExceptionThrown()
        {
            var input = "237283728";
            var actual = DirectionService.GetRobotDirection(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Command not valid. Use R or L")]
        public void GetNewRobotDirection_InvalidCommand_ExceptionThrown()
        {
            DirectionService.GetNewRobotDirection(RobotDirection.W, 'O');
        }

        [TestMethod]
        public void GetNewRobotDirection_NorthR_East()
        {
            var expected = RobotDirection.E;
            var actual = DirectionService.GetNewRobotDirection(RobotDirection.N, 'R');
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetNewRobotDirection_NorthL_West()
        {
            var expected = RobotDirection.W;
            var actual = DirectionService.GetNewRobotDirection(RobotDirection.N, 'L');
            Assert.AreEqual(expected, actual);
        }


        // Continued...
    }
}
