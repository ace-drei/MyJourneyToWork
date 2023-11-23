using Calculator;
using MyJourneyToWork.Pages;
namespace MyJourneyToWorkTest
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyJourneyToWork.Pages;
    using NUnit.Framework;


    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.kms
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(6.21371, convertedDistance, 0.00001); // Allow for small precision error
        }

        [Test]
        public void ConvertDistance_DoesNotConvertMiles()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(10, convertedDistance);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.petrol
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(480, sustainabilityWeighting);
        }


        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForElectricBike()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 8,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 1,
                transportMode = TransportModes.electricbike
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(19.883878151594686, sustainabilityWeighting, 0.000001);
        }





        // ... (previous tests)

        [Test]
        public void ConvertDistance_ReturnsSameDistanceForMiles()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 15,
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(15, convertedDistance);
        }

        [Test]
        public void ConvertDistance_ReturnsZeroForZeroDistance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 0,
                milesOrKms = DistanceMeasurement.kms
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(0, convertedDistance);
        }

        [Test]
        public void SustainabilityWeighting_ReturnsZeroForZeroDays()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 20,
                milesOrKms = DistanceMeasurement.miles,
                numDays = 0,
                transportMode = TransportModes.bus
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }

        [Test]
        public void SustainabilityWeighting_ReturnsZeroForUnknownTransportMode()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 25,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 3,
                transportMode = (TransportModes)999 // Unknown transport mode
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }

        [Test]
        public void SustainabilityWeighting_ReturnsZeroForZeroDistance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 0,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 3,
                transportMode = TransportModes.bus
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }
        [Test]
        public void SustainabilityWeighting_ReturnsZeroForZeroDistanceAndZeroDays()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 0,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 0,
                transportMode = TransportModes.bus
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }
        [Test]
        public void SustainabilityWeighting_ReturnsZeroForZeroDistanceAndZeroDaysAndUnknownTransportMode()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 0,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 0,
                transportMode = (TransportModes)999 // Unknown transport mode
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }
        [Test]
        public void SustainabilityWeighting_ReturnsZeroForZeroDistanceAndZeroDaysAndUnknownTransportModeAndZeroDistance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 0,
                milesOrKms = DistanceMeasurement.kms,
                numDays = 0,
                transportMode = (TransportModes)999 // Unknown transport mode
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(0, sustainabilityWeighting);
        }

        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles_ForCalculatorInstance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.kms
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(6.21371, convertedDistance, 0.00001); // Allow for small precision error
        }

        [Test]
        public void ConvertDistance_DoesNotConvertMiles_ForCalculatorInstance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            var convertedDistance = calculator.convertDistance();

            // Assert
            Assert.AreEqual(10, convertedDistance);
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol_ForCalculatorInstance()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles,
                numDays = 3,
                transportMode = TransportModes.petrol
            };

            // Act
            var sustainabilityWeighting = calculator.sustainabilityWeighting;

            // Assert
            Assert.AreEqual(480, sustainabilityWeighting);
        }

        //Testing for Privacy.cshtml.cs

        [TestFixture]
        public class CalculatorModelTests
        {
            [Test]
            public void OnGet_Should_NotThrowException()
            {
                // Arrange
                var calculatorModel = new CalculatorModel();

                // Act & Assert
                Assert.DoesNotThrow(() => calculatorModel.OnGet());
            }

            [Test]
            public void CalculatorProperty_Should_HaveBindPropertyAttribute()
            {
                // Arrange
                var calculatorProperty = typeof(CalculatorModel).GetProperty("calculator");

                // Act & Assert
                Assert.IsNotNull(calculatorProperty);
                Assert.IsTrue(calculatorProperty.GetCustomAttributes(typeof(BindPropertyAttribute), true).Length > 0);
            }


            //test to see coverage 
            // pt2
        }
    }
}



