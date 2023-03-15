using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeworkSession3_LT.Helpers;
using HomeworkSession3_LT.Resources;
using HomeworkSession3_LT.DataModels;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HomeworkSession3_LT.Tests
{
    [TestClass]
    public class Session3Tests : ApiBaseTest
    {
        private static List<PetJsonModel> petCleanUpList = new List<PetJsonModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        [TestMethod]
        public async Task GetPetById()
        {
            //Arrange
            var getPetRequest = new RestRequest(Endpoints.GetPetById(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act
            var getPetResponse = await RestClient.ExecuteGetAsync<PetJsonModel>(getPetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, getPetResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(PetDetails.Id, getPetResponse.Data.Id, "Pet ID did not match");
            Assert.AreEqual(PetDetails.Name, getPetResponse.Data.Name, "Pet Name did not match");
            Assert.AreEqual(PetDetails.Status, getPetResponse.Data.Status, "Pet Status did not match");
            Assert.AreEqual(PetDetails.Category.Id, getPetResponse.Data.Category.Id, "Category ID did not match"); 
            Assert.AreEqual(PetDetails.Category.Name, getPetResponse.Data.Category.Name, "Category Name did not match");
            Assert.AreEqual(PetDetails.Tags[0].Id, getPetResponse.Data.Tags[0].Id, "Tag ID did not match");
            Assert.AreEqual(PetDetails.Tags[0].Name, getPetResponse.Data.Tags[0].Name, "Tag Name did not match");
            Assert.AreEqual(PetDetails.PhotoUrls[0], getPetResponse.Data.PhotoUrls[0], "PhotoURLs did not match");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoints.GetPetById(data.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }
    }
}
