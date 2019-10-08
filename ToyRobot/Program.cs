using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Model;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = " ";
            var movement = new Movement(5, 5);
            Console.WriteLine("Enter command to control robot: (Type Exit to stop program)");
            Console.WriteLine("Please enter command: ");
            while (true){           
                //Get user input
                
                command = Console.ReadLine();
                var result = movement.execute(command);
                if (command.ToUpper() == "EXIT")
                {
                    break;
                }
                if(result != "")
                {
                    Console.WriteLine(result);
                }
                
            }

            Console.WriteLine("Thank you for your participation");
            Console.ReadLine();

        }
    }
}
