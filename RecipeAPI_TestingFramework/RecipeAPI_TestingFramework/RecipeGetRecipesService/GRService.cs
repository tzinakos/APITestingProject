using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RecipeAPI_TestingFramework
{
    class GRService
    {
        public GetRecipesCallManager GetRecipesCallManager { get; set; } = new GetRecipesCallManager();
        public GetRecipesDTO GetRecipesDTO { get; set; } = new GetRecipesDTO();

        public string Recipe { get; set; }

        public int InstructionsStepCount()
        {
            return GetRecipesDTO.GetSpecifiedRecipe.analyzedInstructions[0].steps.Length;
        }

        public bool CheckIfRecipeIsVegetarian()
        {
            return GetRecipesDTO.GetSpecifiedRecipe.vegetarian == true;
        }
        public GRService()
        {
            Recipe = GetRecipesCallManager.GetRecipes();
            GetRecipesDTO.DeserialiseRecipes(Recipe);
        }
    }
}
