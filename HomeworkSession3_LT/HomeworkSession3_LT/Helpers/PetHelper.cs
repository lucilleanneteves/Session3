using RestSharp;
using HomeworkSession3_LT.DataModels;
using HomeworkSession3_LT.Resources;
using HomeworkSession3_LT.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HomeworkSession3_LT.Helpers
{
    public class PetHelper
    {
        public static async Task<PetJsonModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.createPet();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetJsonModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
