using ElevatorChallenge.Interface;
using ElevatorChallenge.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Model
{
    /// <summary>
    /// The ElevatorSystem class manages the elevators in the building
    /// </summary>
    public class ElevatorSystem : IElevatorSystem
    {
        private readonly Elevator[] elevators;

        public int TopFloor { get; private set; }

        public int ElevatorSizeLimit { get; private set; }

        public int WeightLimit { get; private set; }


        /// <summary>
        /// Initialises a new instance of the ElevatorSystem class with the specified number of elevators, max Floor & max Capacity.
        /// </summary>
        /// <param name="numElevators">The number of Elevators in the building</param>
        /// <param name="maxFloor">The maximum floor of the building</param>
        /// <param name="maxCapacity">The max Capacity of each elavator in the building</param>
        public ElevatorSystem(int numElevators, int maxFloor, int maxCapacity, int weightLimit)
        {
            elevators = new Elevator[numElevators];
            TopFloor = maxFloor;
            ElevatorSizeLimit = maxCapacity;
            WeightLimit = weightLimit;

            for (int i = 0; i < numElevators; i++)
            {
                elevators[i] = new Elevator(i + 1, maxFloor, maxCapacity)
                {
                    WeightLimit = weightLimit
                };
            }
        }


        /// <summary>
        /// Displays the status of all elevators in the building.
        /// </summary>
        public void DisplayElevatorStatus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Elevator Status");

            foreach (var elevator in elevators)
            {
                string direction = elevator.IsGoingUp ? "Up" : "Down";
                string movingStatus = elevator.IsMoving ? "Moving" : "Stopped";

                Console.ForegroundColor = elevator.IsMoving ? ConsoleColor.Green : ConsoleColor.White;
                Console.WriteLine($"{elevator.Id}. Current Floor: {elevator.CurrentFloor}  | Destination Floor: {elevator.DestinationFloor}  | People Inside: {elevator.NumberOfPeopleInside}  | Max-People: {elevator.Capacity}  | Max-Weight: {elevator.WeightLimit} | Direction: {direction}   | Moving Status: {movingStatus}");
            }
        }

        /// <summary>
        /// Get the nearest available elevator to the specified floor and direction with the required capacity.
        /// </summary>
        /// <param name="currentFloor">The current floor where the elevator is called from</param>
        /// <param name="numPeopleWaiting">The number of people waiting for the elevator</param>
        /// <returns>the nearest available elevator or null if no available elevators</returns>
        public Elevator GetNearestElevator(int currentFloor, int numPeopleWaiting)
        {
            var availableElevators = ElevatorFilter.FilterElevators(currentFloor, numPeopleWaiting, WeightLimit, elevators);

            if (availableElevators.Count == 0)
            {
                Console.WriteLine("No available elevators. Please try again later.");
                return null;
            }

            var nearestElevator = availableElevators
                .OrderBy(e => Math.Abs(e.CurrentFloor - currentFloor))
                .ThenBy(e => Math.Abs(e.DestinationFloor - e.CurrentFloor))
                .First();

            nearestElevator.DestinationFloor = currentFloor;

            return nearestElevator;
        }
    }
}
