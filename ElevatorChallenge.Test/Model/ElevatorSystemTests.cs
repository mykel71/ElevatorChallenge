using ElevatorChallenge.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Test.Model
{
    public class ElevatorSystemTests
    {
        [Fact]
        public void GetNearestElevator_Should_ReturnNearestElevator()
        {
            // Arrange
            int currentFloor = 3;
            int numPeopleWaiting = 2;
            int maxFloor = 10;
            int elevatorSizeLimit = 5;
            int weightLimit = 500;

            var elevatorSystem = new ElevatorSystem(3, maxFloor, elevatorSizeLimit, weightLimit);

            // Act
            var nearestElevator = elevatorSystem.GetNearestElevator(currentFloor, numPeopleWaiting);

            // Assert
            Assert.NotNull(nearestElevator);
        }

        [Fact]
        public void GetNearestElevator_NoAvailableElevator()
        {
            // Arrange
            int currentFloor = 3;
            int numPeopleWaiting = 6;
            int maxFloor = 10;
            int elevatorSizeLimit = 5;
            int weightLimit = 500;

            var elevatorSystem = new ElevatorSystem(2, maxFloor, elevatorSizeLimit, weightLimit);

            // Act
            var nearestElevator = elevatorSystem.GetNearestElevator(currentFloor, numPeopleWaiting);

            // Assert
            Assert.Null(nearestElevator);
        }

        [Fact]
        public void GetNearestElevator_ElevatorIsMoving()
        {
            // Arrange
            int currentFloor = 3;
            int numPeopleWaiting = 2;
            int maxFloor = 10;
            int elevatorSizeLimit = 5;
            int weightLimit = 500;

            // Mock the random number generator for the elevator's initial floor
            var randomMock = new Mock<Random>();
            randomMock.Setup(r => r.Next(1, maxFloor + 1)).Returns(currentFloor);

            var elevatorSystem = new ElevatorSystem(2, maxFloor, elevatorSizeLimit, weightLimit);

            // Get the first available elevator (index 0)
            var firstElevator = elevatorSystem.GetNearestElevator(currentFloor, numPeopleWaiting);
            Assert.NotNull(firstElevator);

            // Set the first elevator's destination floor to be different from the current floor (simulating elevator movement)
            firstElevator.DestinationFloor = currentFloor + 2;

            // Try to get another nearest elevator
            var secondNearestElevator = elevatorSystem.GetNearestElevator(currentFloor, numPeopleWaiting);

            // Assert
            Assert.NotNull(secondNearestElevator);
        }
    }
}
