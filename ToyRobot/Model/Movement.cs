using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Model
{
    public class Movement
    {
        private const string INVALID_FORMAT_PLACE = "Invalid command, Please follow the format \nPLACE X, Y, Z";
        private const string OUT_OF_TABLE = "Invalid position, your place position is out of bound";
        private const string NOT_PLACE_ROBOT = "Robot is not placed yet, Please place robot position";
        private const string INVALID_COMAND = "Invalid command, Please follow the format \nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";
        private const string IGNORE_COMAND = "Robot did not understand this command, please try again";


        private int xPosition = 0;
        private int yPosition = 0;

        private int xLimit = 5;
        private int yLimit = 5; 

        private string direction = "";
        private bool checkPlace = false;

        private string[] positionArray = { "NORTH", "EAST", "WEST", "SOUTH" };

        //Initial  a square tabletop  of dimensions 5 units x 5 units
        public Movement(int x, int y)
        {
            xLimit = x;
            yLimit = y;
        }

        //Place robot position
        private string place(string command)
        {
            var result = "";

            var commandArr = command.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if(commandArr.Length < 4)
            {
                result = INVALID_FORMAT_PLACE;
            }
            else
            {
                if(commandArr[0].ToUpper() != "PLACE")
                {
                    result = INVALID_FORMAT_PLACE;
                }
                else
                {
                    xPosition = Int32.Parse(commandArr[1]);
                    yPosition = Int32.Parse(commandArr[2]);
                    direction = commandArr[3];

                    //Check valid direction
                    if (!positionArray.Contains(direction.ToUpper()))
                    {
                        result = INVALID_FORMAT_PLACE;
                        return result;
                    }

                    //Check out of bound
                    if (!checkPosition(xPosition, yPosition))
                    {
                        result = OUT_OF_TABLE;
                        return result;
                    }
                    else
                    {
                        checkPlace = true;
                    }
                }
                
            }
            
            return result;
        }

        //Report robot position
        private string report()
        {
            Console.WriteLine("Robot position is");
            var result = xPosition + "," + yPosition + "," + direction;
            return result;
        }

        //Move robot position
        private string move()
        {
            var result = "";

            //Store the current location before move
            var tempX = xPosition;
            var tempY = yPosition;

            switch (direction)
            {
                case "NORTH":
                    yPosition++; break;
                case "WEST":
                    xPosition--; break;
                case "SOUTH":
                    yPosition--; break;
                case "EAST":
                    xPosition++; break;
            }

            //Check out of bound
            if (!checkPosition(xPosition, yPosition))
            {
                xPosition = tempX;
                yPosition = tempY;

                result = OUT_OF_TABLE;
            }

            return result;
        }

        //Check validated place position
        private bool checkPosition(int xPosition, int yPosition)
        {
            if(xPosition < 0 || yPosition < 0){
                return false;
            }
            else if(xPosition > xLimit || yPosition > yLimit){
                return false;
            }
            else{
                return true;
            }
        }

        //Rotate to left position
        private void left()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "WEST"; break;
                case "WEST":
                    direction = "SOUTH"; break;
                case "SOUTH":
                    direction = "EAST"; break;
                case "EAST":
                    direction = "NORTH"; break;
            }
        }

        //Rotate to right position
        private void right()
        {
            switch (direction)
            {
                case "NORTH":
                    direction = "EAST"; break;
                case "WEST":
                    direction = "NORTH"; break;
                case "SOUTH":
                    direction = "WEST"; break;
                case "EAST":
                    direction = "SOUTH"; break;
            }
        }


        public string execute(string input)
        {
            var command = input.ToUpper();
            var result = "";
            try
            {
                if (command.Contains("PLACE")) {
                    result = place(command);
                }
                else if (!checkPlace)
                {
                    result = NOT_PLACE_ROBOT;
                }
                else if (command.Contains("REPORT")){
                    result = report();
                }
                else if (command.Contains("MOVE")){
                    result = move();
                }
                else if (command.Contains("LEFT"))
                {
                    left();
                }
                else if (command.Contains("RIGHT"))
                {
                    right();
                }
                else
                {
                    result = IGNORE_COMAND;
                }
            }
            catch(Exception e)
            {
                result = INVALID_COMAND;
                Console.WriteLine(e);              
            }

            return result;
        }
    }
}
