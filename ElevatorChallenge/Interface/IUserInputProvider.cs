using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Interface
{
    public interface IUserInputProvider
    {
        int GetPositiveIntegerInput(string prompt);
        int GetNumPeopleWaiting(int maxCapacity, int weightLimit);
        int GetFloorNumber(int maxFloor);
        bool GetDirection();
    }
}
