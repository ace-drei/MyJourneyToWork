using Calculator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyJourneyToWork.Pages;
using System.Reflection;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;

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

        //test for Privacy.cshtml.cs
        //program class




    }
}

//test for Privacy.cshtml.cs

namespace MyJourneyToWorkTest
{
    [TestFixture]
    public class PrivacyModelTests
    {
        [Test]
        public void PrivacyModel_Constructor_ShouldSetLogger()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PrivacyModel>>();

            // Act
            var privacyModel = new PrivacyModel(loggerMock.Object);

            // Assert
            Assert.IsNotNull(privacyModel);
            Assert.IsNotNull(loggerMock.Object);

            // You can add additional assertions if needed
        }

        [Test]
        public void OnGet_ShouldNotThrowExceptions()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<PrivacyModel>>();
            var privacyModel = new PrivacyModel(loggerMock.Object);

            // Act and Assert
            Assert.DoesNotThrow(() => privacyModel.OnGet());
        }
    }
}

//error 



namespace MyJourneyToWorkTest.Pages
{
    [TestFixture]
    public class ErrorModelTests
    {
        [Test]
        public void ShowRequestId_NotNullOrEmpty_ReturnsTrue()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ErrorModel>>();
            var errorModel = new ErrorModel(loggerMock.Object);

            // Act
            errorModel.RequestId = "someRequestId";

            // Assert
            Assert.IsTrue(errorModel.ShowRequestId);
        }

        [Test]
        public void ShowRequestId_NullOrEmpty_ReturnsFalse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ErrorModel>>();
            var errorModel = new ErrorModel(loggerMock.Object);

            // Act
            errorModel.RequestId = null;

            // Assert
            Assert.IsFalse(errorModel.ShowRequestId);
        }

        // Add more tests as needed for other methods or properties in ErrorModel
    }

}



////////



namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ConvertDistance_ConvertsMilesToMiles()
        {
            // Arrange
            var calculator = new Calculator { distance = 10, milesOrKms = DistanceMeasurement.miles };

            // Act
            var result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(10, result, "Conversion from miles to miles should result in the same value");
        }

        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {
            // Arrange
            var calculator = new Calculator { distance = 10, milesOrKms = DistanceMeasurement.kms };

            // Act
            var result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(6.21371, result, 0.00001, "Conversion from kilometers to miles is incorrect");
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol()
        {
            // Arrange
            var calculator = new Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.petrol
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(800, result, "Sustainability weighting calculation for petrol is incorrect");
        }

        // Add similar tests for other transport modes...
    }
}
