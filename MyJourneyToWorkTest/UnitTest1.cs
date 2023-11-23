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

    }
}
