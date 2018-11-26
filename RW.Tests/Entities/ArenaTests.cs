using Microsoft.VisualStudio.TestTools.UnitTesting;
using RW.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Tests.Entities
{
    [TestClass]
    public class ArenaTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot position invalid. Out of bounds.")]
        public void ValidateRobot_BelowZero_ExceptionThrown()
        {
            var arena = Arena.Create(5, 5);
            arena.ValidateRobot(-5, -5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot position invalid. Out of bounds.")]
        public void ValidateRobot_OverXLimit_ExceptionThrown()
        {
            var arena = Arena.Create(5, 5);
            arena.ValidateRobot(10, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Robot position invalid. Out of bounds.")]
        public void ValidateRobot_OverYLimit_ExceptionThrown()
        {
            var arena = Arena.Create(5, 5);
            arena.ValidateRobot(3, 10);
        }

    }
}
