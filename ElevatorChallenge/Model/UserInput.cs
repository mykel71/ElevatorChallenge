using ElevatorChallenge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Model
{
    /// <summary>
    /// Class containing static methods for getting user inpt
    /// </summary>
    public class UserInput
    {
        private readonly IUserInputProvider userInputProvider;

        public UserInput(IUserInputProvider userInputProvider)
        {
            this.userInputProvider = userInputProvider;
        }


        /// <summary>
        /// Initialise a new instance of the ElevatorSystem class with user-specified settings
        /// </summary>
        /// <returns>A new instance of the ElevatorSystem class</returns>
        public static ElevatorSystem InitializeElevatorSystem()
        {
            Console.Clear();
            Console.Title = "Shepherd M Munemo - DVT - Elevator Challenge";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("##########################################");
            Console.WriteLine("####     DVT Elevator Challenge App   ####");
            Console.WriteLine("##########################################");
            Console.WriteLine("\n\nInitialize the Elevator System by entering the following: ...\n\n");

            // Get user input for the number of elevators
            int numElevators = GetPositiveIntegerInput("Enter the number of Elevators: ");

            // Get user input for the maximum floor            
            int maxFloor = GetPositiveIntegerInput("Enter the total number of Floors: ");

            // Get user input for the maximum capacity
            int maxCapacity = GetPositiveIntegerInput("Enter the maximum number of people allowed: ");

            // Get user input for the maximum weightLimit
            int weightLimit = GetPositiveIntegerInput("Enter the maximum weight allowed: ");

            // Create and return a new ElevatorSystem instance
            return new ElevatorSystem(numElevators, maxFloor, maxCapacity, weightLimit);
        }


        /// <summary>
        /// Prompts the user to enter a floor number between 1 and the specified maximum floor and returns the user's input as integer
        /// </summary>
        /// <param name="maxFloor">The maximum allowed floor number</param>
        /// <returns>Th user's input floor number as an integer</returns>
        public static int GetFloorNumber(int maxFloor)
        {
            int floor;

            do
            {
                Console.WriteLine($"\nPlease enter your number (1 - {maxFloor}):\n");
                string floorInput = Console.ReadLine();

                bool isFloorValid = int.TryParse(floorInput, out floor) && floor >= 1 && floor <= maxFloor;

                if (!isFloorValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid floor number. Please enter a number between 1 and {maxFloor}.\n");
                    Console.ResetColor();
                }
            }
            while (floor < 1 || floor > maxFloor);

            return floor;
        }


        /// <summary>
        /// Prompts the user to enter a direction (up or down) and returns the user's input as a boolean.
        /// </summary>
        /// <returns>True if the user enters 1 (up), false if the user enters 0 (down)</returns>
        public static bool GetDirection(string input)
        {
            int direction;

            do
            {
                Console.WriteLine("\nPlease enter your direction (1 for up, 0 for down): \n");
                var directionInput = Console.ReadLine();

                var isDirectionValid = int.TryParse(directionInput, out direction) && (direction == 0 || direction == 1);

                if (!isDirectionValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid direction. Please enter 1 for up or 0 for down.\n");
                    Console.ResetColor();
                }
            }
            while (direction != 0 && direction != 1);

            return direction == 1;
        }

        /// <summary>
        /// Propmpts the user to enter the number of people waiting (up to the specified maximum capacity) and returns the user inpt as a integer
        /// </summary>
        /// <param name="maxCapacity">The maximum Capacity of the elevator</param>
        /// <returns>The user's input number of people waiting as an integer</returns>
        public static int GetNumPeopleWaiting(int maxCapacity, int weightLimit)
        {
            int numPeople;
            int totalWeight;

            do
            {
                Console.WriteLine($"\nPlease enter the number of people waiting (up to {maxCapacity}): ");
                string numPeopleInput = Console.ReadLine();

                Console.WriteLine($"\nPlease enter the total Weight of people waiting (up to {weightLimit}): ");
                string totalWeightInput = Console.ReadLine();

                bool isNumPeopleValid = int.TryParse(numPeopleInput, out numPeople) && numPeople >= 0 && numPeople <= maxCapacity;
                bool isTotalWeightValid = int.TryParse(totalWeightInput, out totalWeight) && totalWeight >= 0 && totalWeight <= weightLimit;

                if (!isNumPeopleValid || !isTotalWeightValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid input. Please enter a valid number of people (between 1 and {maxCapacity}) and valid total weight (between 1 and {weightLimit}. \n");
                    Console.ResetColor();
                }
            }
            while (numPeople < 0 || numPeople > maxCapacity || totalWeight < 0 || totalWeight > weightLimit);

            return numPeople;
        }



        /// <summary>
        /// Prompts the user to select the floor they want to go to and returns the selected floor as an integer.
        /// </summary>
        /// <param name="currentFloor">The current floor of the elevator</param>
        /// <param name="elevator">The elevator that the user is using</param>
        /// <returns>The selected destination floor as an Integer</returns>
        public static int GetDestinationFloor(int currentFloor, Elevator elevator)
        {
            int destinationFloor;
            bool isDestinationFloorValid;

            do
            {
                Console.WriteLine($"\nElevator {elevator.Id} has arrived at floor {elevator.CurrentFloor}.\n");
                Console.WriteLine($"\nPlease select the floor that you are going to (current: {currentFloor}):\n");
                string destinationFloorInput = Console.ReadLine();

                isDestinationFloorValid = int.TryParse(destinationFloorInput, out destinationFloor) && destinationFloor >= 1 && destinationFloor <= elevator.MaxFloor;

                if (!isDestinationFloorValid)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid destination floor. Please enter a number between 1 and {elevator.MaxFloor}.\n");
                    Console.ResetColor();
                }
                else if (destinationFloor == currentFloor)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nYou are already on floor {destinationFloor}. Please select another floor.\n");
                    Console.ResetColor();
                    isDestinationFloorValid = false;
                }
            }
            while (!isDestinationFloorValid);

            elevator.DestinationFloor = destinationFloor;
            return destinationFloor;
        }



        /// <summary>
        /// Prompt the user to input a positive integer value and returns the value as an integer.
        /// </summary>
        /// <param name="prompt">The prompt message to display to the user</param>
        /// <returns>the user input as an integer</returns>
        public static int GetPositiveIntegerInput(string prompt/*, IUserInputProvider userInputProvider*/)
        {
            int value = 0;

            while (value <= 0)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Input. Please enter a positive integer.\n");
                    Console.ResetColor();
                }
            }

            return value;
        }
    }
}
