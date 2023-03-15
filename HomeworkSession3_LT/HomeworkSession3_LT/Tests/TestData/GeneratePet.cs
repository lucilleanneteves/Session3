using HomeworkSession3_LT.DataModels;
using System;
using System.Collections.Generic;

namespace HomeworkSession3_LT.Tests.TestData
{
    public class GeneratePet
    {
        public static PetJsonModel createPet()
        {
            return new PetJsonModel
            {
                Id = 40,
                Category = new Category()
                {
                    Id = 98,
                    Name = "Shih-tzu"
                },
                Name = "Choco",
                PhotoUrls = new List<string> { "photoUrl1", "photoUrl2" },
                Tags = new Category[] { new Category { Id = 102, Name = "Dog" } },
                Status = "sold"
                
        };
        }
    }
}
