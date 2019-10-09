using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot.Model;

namespace ToyRobotTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Robot_TEST_WhenNotPlacedYet()
        {
            //arrange
            var movement = new Movement(5,5);
            //act
            var result = movement.execute("REPORT");
            //assert
            Assert.AreEqual(Movement.NOT_PLACE_ROBOT, result);
        }

        [TestMethod]
        public void Robot_TEST_AfterBeingPlaced()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 0,0,NORTH");
            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void Robot_TEST_Report_AfterBeingPlaced()
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
        public void Robot_TEST_CASE_A()
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

        [TestMethod]
        public void Robot_TEST_CASE_B()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 0,0,NORTH");
            result = movement.execute("LEFT");
            result = movement.execute("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }


        [TestMethod]
        public void Robot_TEST_CASE_C()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 1,2,EAST");
            result = movement.execute("MOVE");
            result = movement.execute("MOVE");
            result = movement.execute("LEFT");
            result = movement.execute("MOVE");
            result = movement.execute("REPORT");
            //assert
            Assert.AreEqual("3,3,NORTH", result);
        }


        //Invalid place - out of bound 
        [TestMethod]
        public void Robot_TEST_PLACE_OUT_OF_BOUND()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 0,10,NORTH");
            //assert
            Assert.AreEqual(Movement.OUT_OF_TABLE, result);
        }

        [TestMethod]
        public void Robot_TEST_MOVE_OUT_OF_BOUND()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 4,5,NORTH");
            result = movement.execute("MOVE");
            //assert
            Assert.AreEqual(Movement.OUT_OF_TABLE, result);
        }

        [TestMethod]
        public void Robot_TEST_INVALID_FORMAT_PLACE()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 4,NORTH");
            //assert
            Assert.AreEqual(Movement.INVALID_FORMAT_PLACE, result);
        }


        [TestMethod]
        public void Robot_TEST_INVALID_FORMAT_PLACE_SYNTAX()
        {
            //arrange
            var movement = new Movement(5, 5);
            //act
            var result = movement.execute("PLACE 4,4,NORTHERN");
            //assert
            Assert.AreEqual(Movement.INVALID_FORMAT_PLACE, result);
        }
    }
}
