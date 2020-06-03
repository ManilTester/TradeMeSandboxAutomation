using APIAutomationFramework.Support;
using Newtonsoft.Json;
using RestSharp;
using TradeMeAPIAutomationFramework.Models;

namespace APIAutomationFramework.ServiceObject
{
    internal class APISandboxServices
    {

        public IRestResponse GetUsedCarCategoryList()
        {
            var usedCarCategoryEndpoint = GetEndpoint("usedCarCategory");

            var client = new RestClient(usedCarCategoryEndpoint);
            var request = new RestRequest(Method.GET);

            var response = client.Execute(request);
            return response;
        }

        public Categories GetUserCarCategories(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<Categories>(response.Content);
        }

        private static string GetEndpoint(string endpoint)
        {
            var env = TestConfiguration.GetEnvironmentInfo();
            return env[endpoint];
        }

        /// <summary>
        /// Verifies if a brand is present in the Car Category List
        /// </summary>
        /// <param name="carCategoryList"></param>
        /// <param name="brandName"></param>
        /// <returns></returns>
        internal bool? IsBrandPresentInTheList(Categories carCategoryList, string brandName)
        {
            return carCategoryList.Subcategories.Exists(s => s.Name == brandName);
        }
    }
}
