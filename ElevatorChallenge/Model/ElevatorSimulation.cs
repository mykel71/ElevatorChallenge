using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Model
{
    /// <summary>
    /// Contains methods for simulating of an elevator to its destination floor
    /// </summary>
    public class ElevatorSimulation
    {
        public static void SimulateElevatorMovement(Elevator elevator, Action displayElevatorStatus)
        {
            Console.WriteLine($"Elevator {elevator.Id} is in motion.");

            elevator.IsMoving = true;

            // Simulate elevate moving to the destination floor
            while (elevator.CurrentFloor != elevator.DestinationFloor)
            {
                if (elevator.CurrentFloor < elevator.DestinationFloor)
                {
                    elevator.IsGoingUp = true;
                    elevator.CurrentFloor++;
                }
                else
                {
                    elevator.IsGoingUp = false;
                    elevator.CurrentFloor--;
                }

                displayElevatorStatus();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNOTE: Simulation elevator movement is at 1sec/floor.");
                Thread.Sleep(1000); // Pause for 1 sec to simulate elevator movement
                Console.ResetColor();
            }

            elevator.IsMoving = false;
            displayElevatorStatus();

            var peopleMessage = elevator.NumberOfPeopleInside > 0 ? $"with {elevator.NumberOfPeopleInside} person/people" : string.Empty;

            Console.WriteLine($"\nElevator {elevator.Id} has arrived at your floor {elevator.DestinationFloor} {peopleMessage}.\n");

            // Reset the number of people in the elevator
            elevator.NumberOfPeopleInside = 0;
        }

    }




}
