using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElevatorChallenge.Model;

namespace ElevatorChallenge.Interface
{
    public interface IElevatorSystem
    {
        int TopFloor { get; }
        int ElevatorSizeLimit { get; }

        void DisplayElevatorStatus();
        Elevator GetNearestElevator(int currentFloor, int numPeopleWaiting);

    }
}
