using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Interface
{
    public interface IElevator
    {
        public int Id { get; set; } // Gets the identifier of the elevator

        public int CurrentFloor { get; set; }

        public int DestinationFloor { get; set; }
  
        public int MaxFloor { get; set; }

        public int Capacity { get; set; }

        public int NumberOfPeopleInside { get; set; }
        public int WeightLimit { get; set; }

        public bool IsMoving { get; set; }

        public bool IsGoingUp { get; set; }
    }
}
