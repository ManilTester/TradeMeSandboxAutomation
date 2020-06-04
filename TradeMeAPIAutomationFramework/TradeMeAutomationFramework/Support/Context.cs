using RestSharp;
using TradeMeAPIAutomationFramework.Models;

namespace APIAutomationFramework.Support
{
    public class Context
    {
        public IRestResponse Response { get; internal set; }
        public Categories CarCategoryList { get; internal set; }
    }
}
