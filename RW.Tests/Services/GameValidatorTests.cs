using Microsoft.VisualStudio.TestTools.UnitTesting;
using RW.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Tests.Services
{
    [TestClass]
    public class GameValidatorTests
    {
        private IGameValidator GameValidator = new MockupCreator().GetGameValidator();

        [TestMethod]
        public void IRobotPositionValidator_ValidInput_IsValidTrue()
        {
            var input = "1 1 N";
            var expected = true;
            var actual = (GameValidator as IRobotPositionValidator).Validate(input);
            Assert.AreEqual(expected, actual.IsValid);
        }

        [TestMethod]
        public void IRobotPositionValidator_StartWithString_IsValidFalse()
        {
            var input = "N 1 1 N";
            var expected = false;
            var actual = (GameValidator as IRobotPositionValidator).Validate(input);
            Assert.AreEqual(expected, actual.IsValid);
        }

        [TestMethod]
        public void IRobotPositionValidator_AllInts_IsValidFalse()
        {
            var input = "1 1 1";
            var expected = false;
            var actual = (GameValidator as IRobotPositionValidator).Validate(input);
            Assert.AreEqual(expected, actual.IsValid);
        }

        [TestMethod]
        public void IRobotPositionValidator_NegativeNumber_IsValidFalse()
        {
            var input = "-2 -1 N";
            var expected = false;
            var actual = (GameValidator as IRobotPositionValidator).Validate(input);
            Assert.AreEqual(expected, actual.IsValid);
        }



    }
}
