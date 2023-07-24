using ElevatorChallenge.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Test.Mocks
{
    public class MockUserInputProvider : IUserInputProvider
    {
        private int[] inputValues;
        private int currentIndex = 0;

        public MockUserInputProvider(params int[] inputValues)
        {
            this.inputValues = inputValues;
        }

        public int GetPositiveIntegerInput(string prompt)
        {
            return inputValues[currentIndex++];
        }

        public int GetNumPeopleWaiting(int maxCapacity, int weightLimit)
        {
            return 0;
        }

        public int GetFloorNumber(int maxFloor)
        {
            return 0;
        }

        public bool GetDirection()
        {
            return false;
        }
    }
}
