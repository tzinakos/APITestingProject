
using NUnit.Framework;
using System;

namespace RecipeAPI_TestingFramework
{
    
    public class GetRecipesTest
    {
        private GRService _ReturnedRecipe = new GRService();

        
        [Test]
        public void RecipeIsVegetarianReturnsTrueBool()
        {
            Assert.That(_ReturnedRecipe.CheckIfRecipeIsVegetarian());
        }

        [Test]
        public void RecipeInstructionStepCountIs7()
        {
            Assert.That(_ReturnedRecipe.InstructionsStepCount(), Is.EqualTo(7));
        }
    }
}
