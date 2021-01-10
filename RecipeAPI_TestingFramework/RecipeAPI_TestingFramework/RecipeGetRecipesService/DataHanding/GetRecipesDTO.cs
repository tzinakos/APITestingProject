using System;
using Newtonsoft.Json;

namespace RecipeAPI_TestingFramework 
{ 
    class GetRecipesDTO
    {
        public GetRecipesRoot GetSpecifiedRecipe { get; set; }
        public void DeserialiseRecipes(string recipeResponse)
        {
            GetSpecifiedRecipe = JsonConvert.DeserializeObject<GetRecipesRoot>(recipeResponse);
        }
    }
}
