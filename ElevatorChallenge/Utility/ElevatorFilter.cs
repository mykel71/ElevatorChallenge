using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Model;

namespace ElevatorChallenge.Utility
{
    public class ElevatorFilter
    {
        /// <summary>
        /// Filters the list of elevators based on the current floor and number of people waiting
        /// </summary>
        /// <param name="currentFloor">the current floor of the requester</param>
        /// <param name="numPeopleWaiting">The number of people waiting for the elevator</param>
        /// <param name="elevators">The List of elevators to filter.</param>
        /// <returns>A list of elevators that can service the request.</returns>
        public static List<Elevator> FilterElevators(int currentFloor, int numPeopleWaiting, int totalWeight, Elevator[] elevators)
        {
            // Add targeted floor to filter
            var availableElevators = elevators
                .Where(
                    e =>
                    e.Capacity >= numPeopleWaiting &&
                    e.NumberOfPeopleInside + numPeopleWaiting <= e.Capacity &&
                    e.WeightLimit >= totalWeight &&
                    ((e.CurrentFloor <= currentFloor && e.IsGoingUp) ||
                    (e.CurrentFloor >= currentFloor && !e.IsGoingUp) ||
                    !e.IsMoving))
                .ToList();

            return availableElevators;
        }
    }
}
