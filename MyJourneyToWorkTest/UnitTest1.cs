using Calculator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;
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
        [Test]
        public void OnGet_SetsRequestIdFromHttpContext()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ErrorModel>>();
            var httpContextMock = new Mock<HttpContext>();
            var traceIdentifier = "testTraceIdentifier";
            httpContextMock.Setup(c => c.TraceIdentifier).Returns(traceIdentifier);

            var errorModel = new ErrorModel(loggerMock.Object)
            {
                PageContext = new PageContext
                {
                    HttpContext = httpContextMock.Object
                }
            };

            // Act
            errorModel.OnGet();

            // Assert
            Assert.AreEqual(traceIdentifier, errorModel.RequestId);
        }

    }

    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ConvertDistance_ConvertsMilesToMiles()
        {
            // Arrange
            var calculator = new Calculator.Calculator { distance = 10, milesOrKms = DistanceMeasurement.miles };

            // Act
            var result = calculator.convertDistance();

            // Assert
            Assert.AreEqual(10, result, "Conversion from miles to miles should result in the same value");
        }

        [Test]
        public void ConvertDistance_ConvertsKilometersToMiles()
        {

            var calculator = new Calculator.Calculator { distance = 10, milesOrKms = DistanceMeasurement.kms };


            var result = calculator.convertDistance();


            Assert.AreEqual(6.21371, result, 0.00001, "Conversion from kilometers to miles is incorrect");
        }

        [Test]
        public void SustainabilityWeighting_CalculatesCorrectlyForPetrol()
        {

            var calculator = new Calculator.Calculator
            {
                distance = 10,
                milesOrKms = DistanceMeasurement.miles,
                numDays = 5,
                transportMode = TransportModes.petrol
            };


            var result = calculator.sustainabilityWeighting;


            Assert.AreEqual(800, result, "Sustainability weighting calculation for petrol is incorrect");
        }

        [Test]
        public void OnGet_DoesNotThrowException()
        {

            var loggerMock = new Mock<ILogger<IndexModel>>();
            var indexModel = new IndexModel(loggerMock.Object);


            Assert.DoesNotThrow(() => indexModel.OnGet(), "OnGet should not throw an exception");
        }

        [TestFixture]
        public class CalculatorTests1
        {
            [Test]
            public void ConvertDistance_WhenInMiles_ReturnsSameDistance()
            {

                var calculator = new Calculator.Calculator
                {
                    distance = 20,
                    milesOrKms = DistanceMeasurement.miles
                };


                var convertedDistance = calculator.convertDistance();


                Assert.AreEqual(20, convertedDistance);
            }

            [Test]
            public void ConvertDistance_WhenInKilometers_ReturnsConvertedDistance()
            {

                var calculator = new Calculator.Calculator
                {
                    distance = 20,
                    milesOrKms = DistanceMeasurement.kms
                };

                var convertedDistance = calculator.convertDistance();


                Assert.AreEqual(20 / 1.609344, convertedDistance, 0.0001);
            }

            [Test]
            public void SustainabilityWeighting_CalculatesCorrectly()
            {

                var calculator = new Calculator.Calculator
                {
                    distance = 20,
                    milesOrKms = DistanceMeasurement.miles,
                    numDays = 3,
                    transportMode = TransportModes.petrol
                };


                var sustainabilityWeighting = calculator.sustainabilityWeighting;

                Assert.AreEqual(20 * 8 * 3 * 2, sustainabilityWeighting);
            }



        }

        public class CalculatorModelTests
        {
            private CalculatorModel _calculatorModel;
            private Mock<ISession> _session;
            private Dictionary<string, byte[]> _sessionStorage;

            [SetUp]
            public void Setup()
            {
                _sessionStorage = new Dictionary<string, byte[]>();
                _session = new Mock<ISession>();

                _session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()))
                        .Callback<string, byte[]>((key, value) => _sessionStorage[key] = value);

                _session.Setup(s => s.TryGetValue(It.IsAny<string>(), out It.Ref<byte[]>.IsAny))
                        .Returns((string key, out byte[] value) =>
                        {
                            value = _sessionStorage.ContainsKey(key) ? _sessionStorage[key] : null;
                            return _sessionStorage.ContainsKey(key);
                        });

                var context = new DefaultHttpContext { Session = _session.Object };
                var pageContext = new PageContext(new ActionContext
                {
                    HttpContext = context,
                    RouteData = new RouteData(),
                    ActionDescriptor = new PageActionDescriptor()
                });

                _calculatorModel = new CalculatorModel
                {
                    PageContext = pageContext,
                    calculator = new Calculator.Calculator()
                };
            }

            [Test]
            public void AddCalculationToHistory_Test()
            {

                _calculatorModel.calculator.distance = 10;
                _calculatorModel.calculator.numDays = 5;
                _calculatorModel.calculator.transportMode = Calculator.TransportModes.petrol;


                _calculatorModel.OnPost();


                _session.Verify(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()), Times.Once);
                Assert.IsTrue(_sessionStorage.ContainsKey("CalculationHistory"));
            }

            [Test]
            public void RetrieveEmptyCalculationHistory_Test()
            {

                var history = _calculatorModel.GetCalculationHistory();


                Assert.IsNotNull(history);
                Assert.IsEmpty(history);
            }

            [Test]
            public void OnGet_InitializesDataCorrectly()
            {

                var model = new CalculatorModel();


                model.OnGet();

            }
        }
    }
}

