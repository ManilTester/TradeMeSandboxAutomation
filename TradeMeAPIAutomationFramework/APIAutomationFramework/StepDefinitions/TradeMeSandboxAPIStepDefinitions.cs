using APIAutomationFramework.ServiceObject;
using APIAutomationFramework.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TradeMeAPIAutomationFramework.StepDefinitions
{
    [Binding]
    public sealed class TradeMeSandboxAPIStepDefinitions
    {
        private readonly APISandboxServices apiSandboxServices;
        private readonly Context context;

        public TradeMeSandboxAPIStepDefinitions()
        {
            context = new Context();
            apiSandboxServices = new APISandboxServices();
        }

        [Given(@"I run the API to get used car categories")]
        public void GivenIRunTheAPIToGetUsedCarCategories()
        {
            context.Response = apiSandboxServices.GetUsedCarCategoryList();
        }

        [Then(@"I verify the API to Get Categories of Used Cars ran successfully")]
        public void ThenIVerifyTheAPIToGetCategoriesForUsedCarsRanSuccessfully()
        {
            Assert.IsTrue(context.Response.IsSuccessful, "Get User Car Categoried API failed to run successfully");
        }

        [Then(@"I verify the number of brands returned are equal to (.*)")]
        public void ThenIVerifyTheNumberOfBrandsReturnedAreEqualTo(int expectedBrandsCount)
        {
            context.CarCategoryList = apiSandboxServices.GetUserCarCategories(context.Response);
            var actualListedBrandsCount = context.CarCategoryList.Subcategories.Count;

            Assert.AreEqual(expectedBrandsCount, actualListedBrandsCount, "Expected Used Car Listed Count : " + expectedBrandsCount + " Actual Listed Brand Count : " + actualListedBrandsCount);
        }

        [Then(@"I verify that the returned brand list contains brand : ""(.*)""")]
        public void ThenIVerifyThatTheReturnedBrandListContainsBrand(string brandName)
        {
            Assert.IsTrue(apiSandboxServices.IsBrandPresentInTheList(context.CarCategoryList,brandName));
        }

        [Then(@"I verift that the returned brand list doesn't contain brand : ""(.*)""")]
        public void ThenIVeriftThatTheReturnedBrandListDoesnTContainBrand(string brandName)
        {
            Assert.IsFalse(apiSandboxServices.IsBrandPresentInTheList(context.CarCategoryList, brandName));
        }
    }
}
