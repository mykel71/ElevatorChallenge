using ElevatorChallenge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Model
{
    /// <summary>
    /// This class represents an elevator thatcan move between floors and transport people
    /// </summary>
    public class Elevator : IElevator
    {
        public int Id { get; set; }
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public int MaxFloor { get; set; }
        public int Capacity { get; set; }
        public int NumberOfPeopleInside { get; set; }
        public int WeightLimit { get; set; }
        public bool IsMoving { get; set; }
        public bool IsGoingUp { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="Elevator"/> class with the specified indentifier, maximum floor and capacity.
        /// </summary>
        /// <param name="id">the unique identifier of the Elevator</param>
        /// <param name="maxFloor">The maximum floor that the elevator can travel to</param>
        /// <param name="capacity">The maximum number of people that the elevator can transport</param>
        public Elevator(int id, int maxFloor, int capacity)
        {
            var rd = new Random();
            Id = id;
            MaxFloor = maxFloor;
            Capacity = capacity;
            CurrentFloor = rd.Next(1, maxFloor + 1);
            DestinationFloor = CurrentFloor;
            IsGoingUp = true;
        }
    }
}
