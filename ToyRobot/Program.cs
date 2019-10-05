using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = " ";

            Console.WriteLine("Enter command to control robot: (Type Exit to stop program)");

            while (true){
                
                //Get user input
                Console.WriteLine("Please enter command: ");
                command = Console.ReadLine();
                
                if(command.ToUpper() == "EXIT")
                {
                    break;
                }


                Console.WriteLine();
            }

            Console.WriteLine("Thank you for your participation");
            Console.ReadLine();

        }
    }
}
