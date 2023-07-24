using System;
using System.Threading;
using ElevatorChallenge.Interface;
using ElevatorChallenge.Model;

public class Program
{
    public static void Main()
    {

        var building = UserInput.InitializeElevatorSystem();

        while (true)
        {
            building.DisplayElevatorStatus();

            var floorNum = UserInput.GetFloorNumber(building.TopFloor);
            var people = UserInput.GetNumPeopleWaiting(building.ElevatorSizeLimit, building.WeightLimit);

            var elevator = building.GetNearestElevator(floorNum, people);

            if (elevator == null)
            {
                // No available elevator, go back to the beginning of the loop
                continue;
            }

            ElevatorSimulation.SimulateElevatorMovement(elevator, building.DisplayElevatorStatus);

            var destinationFloor = UserInput.GetDestinationFloor(floorNum, elevator);
            elevator.NumberOfPeopleInside = people;

            ElevatorSimulation.SimulateElevatorMovement(elevator, building.DisplayElevatorStatus);

            Console.WriteLine("Simulation completed, press any key to run again or 'q' to quit....");
            var userChoice = Console.ReadLine();

            if (userChoice.ToLower() == "q")
            {
                break;
            }
        }
    }
}
