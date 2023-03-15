using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using HomeworkSession3_LT.DataModels;

namespace HomeworkSession3_LT.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public PetJsonModel PetDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }

    }
}
