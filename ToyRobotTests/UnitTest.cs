using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Model;

namespace ToyRobotTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Robot_WhenNotPlacedYet()
        {
            //arrange
            var movement = new Movement(5,5);
            //act
            var result = movement.execute("REPORT");
            //assert
            Assert.AreEqual(Movement.NOT_PLACE_ROBOT, result);
        }

        [TestMethod]
        public void Robot_AfterBeingPlaced()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 0,0,NORTH");
            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Robot_Report_AfterBeingPlaced()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            string result = movement.execute("PLACE 0,0,NORTH");
            result = movement.execute("REPORT");
            //assert
            Assert.AreEqual("0,0,NORTH", result);
        }

        [TestMethod]
        public void Robot_Report_0_1_N_AfterPlaced_0_0_N_AndSingleMove()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 0,0,NORTH");
            result = movement.execute("MOVE");
            result = movement.execute("REPORT");
            //assert
            Assert.AreEqual("0,1,NORTH", result);
        }

    }
}
