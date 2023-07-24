using ElevatorChallenge.Interface;
using ElevatorChallenge.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Test.Model
{
    public class UserInputTests
    {
        [Theory]
        [InlineData("5", 5)]
        public void GetPositiveIntegerInput_ValidInput_ReturnsCorrectValue(string input, int expectedValue)
        {
            // Arrange
            string prompt = "Enter a positive integer: ";

            // Act
            int result = UserInput.GetPositiveIntegerInput(input);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("3", 5, 2)]
        public void GetDestinationFloor_ValidInput_ReturnsCorrectValue(string destinationFloorInput, int maxFloor, int expectedDestinationFloor)
        {
            // Arrange
            int currentFloor = 2;
            int elevatorId = 1;
            var elevator = new Elevator(elevatorId, currentFloor, maxFloor);

            // Act
            int destinationFloor = UserInput.GetDestinationFloor(currentFloor, elevator);

            // Assert
            Assert.Equal(expectedDestinationFloor, destinationFloor);
        }
    }
}
