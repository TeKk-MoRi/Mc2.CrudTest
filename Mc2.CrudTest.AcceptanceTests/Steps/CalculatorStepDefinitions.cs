namespace Mc2.CrudTest.AcceptanceTests.Steps
{
    using TechTalk.SpecFlow;
    using NUnit.Framework;

    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _scenarioContext.Add("FirstNumber", number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            int firstNumber = _scenarioContext.Get<int>("FirstNumber");
            int secondNumber = _scenarioContext.Get<int>("SecondNumber");

            int result = firstNumber + secondNumber;

            _scenarioContext.Add("Result", result);
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            int actualResult = _scenarioContext.Get<int>("Result");

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
