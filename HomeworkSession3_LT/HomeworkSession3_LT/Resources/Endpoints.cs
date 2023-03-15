﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkSession3_LT.Resources
{
    public class Endpoints
    {
        //Base URL
        public const string baseURL = "https://petstore.swagger.io/v2";

        public static string GetPetById(long id) => $"{baseURL}/pet/{id}";

        public static string PostPet() => $"{baseURL}/pet";

        public static string DeletePetById(long id) => $"{baseURL}/user/{id}";
    }
}
