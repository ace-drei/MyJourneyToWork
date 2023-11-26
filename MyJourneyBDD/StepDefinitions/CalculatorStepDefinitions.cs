using Calculator;
using NUnit.Framework;
using TechTalk.SpecFlow;


[Binding]
public class CalculatorSteps
{
    private Calculator.Calculator? calculator;

    [Given(@"I have a distance of (.*) miles")]
    public void GivenIHaveADistanceOfMiles(double distance)
    {
        calculator = new Calculator.Calculator { distance = distance, milesOrKms = DistanceMeasurement.miles };
    }

    [Given(@"I travel to work for (.*) days")]
    public void GivenITravelToWorkForDays(int numDays)
    {
        if (calculator == null)
        {
            throw new InvalidOperationException("Calculator is not initialized.");
        }

        calculator.numDays = numDays;
    }

    [When(@"I select the transport mode as (.*)")]
    public void WhenISelectTheTransportModeAs(string transportMode)
    {
        calculator.transportMode = Enum.Parse<TransportModes>(transportMode.ToLower());
    }

    [Then(@"the Sustainability Weighting should be calculated as (.*)")]
    public void ThenTheSustainabilityWeightingShouldBeCalculatedAs(double expectedWeighting)
    {
        double actualWeighting = calculator.sustainabilityWeighting;
        Assert.That(actualWeighting, Is.EqualTo(expectedWeighting));
    }
}
