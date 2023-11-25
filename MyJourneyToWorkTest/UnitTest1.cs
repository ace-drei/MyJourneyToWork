using Calculator;
using Microsoft.AspNetCore.Mvc;
using MyJourneyToWork.Pages;

namespace MyJourneyToWorkTest
{
    public class Tests
    {

        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 160.9344, // 100 kilometers
                milesOrKms = DistanceMeasurement.kms
            };

            // Act
            var result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void ConvertDistance_LeavesMilesUnchanged()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 100, // 100 miles
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            var result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(100, result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 50, // 50 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.petrol
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(8 * 50 * (3 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForCycling()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10, // 10 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.cycling
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0.005 * 10 * (5 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForDiesel()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 40, // 40 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 4,
                transportMode = TransportModes.deisel
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(10 * 40 * (4 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForHybrid()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 30, // 30 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 2,
                transportMode = TransportModes.hybrid
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(6 * 30 * (2 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForElectric()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 20, // 20 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 7,
                transportMode = TransportModes.electric
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(4 * 20 * (7 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForMotorbike()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 15, // 15 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 6,
                transportMode = TransportModes.motorbike
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(3 * 15 * (6 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForElectricBike()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 8, // 8 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 1,
                transportMode = TransportModes.electricbike
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(2 * 8 * (1 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForTrain()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 100, // 100 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.train
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(3 * 100 * (3 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForBus()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 25, // 25 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.bus
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(3 * 25 * (5 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForTram()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 15, // 15 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 2,
                transportMode = TransportModes.tram
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(3 * 15 * (2 * 2), result);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForWalking()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 5, // 5 miles
                milesOrKms = DistanceMeasurement.miles,
                numDays = 7,
                transportMode = TransportModes.walking
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0.005 * 5 * (7 * 2), result);
        }




    }
}
