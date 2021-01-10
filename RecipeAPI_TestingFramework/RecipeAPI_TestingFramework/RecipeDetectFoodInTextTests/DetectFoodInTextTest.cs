
using NUnit.Framework;
using System;

namespace RecipeAPI_TestingFramework
{
    
    public class DetectFoodInTextTest
    {
        readonly static string[] dishes = new string[] { "burger", "pizza", "sirloin", "steak" };
        readonly static string[] ingredients = new string[] {"salt","sugar","lemon","tomato" };

        readonly static Random random = new Random();

        readonly static string selectedDish = dishes[random.Next(dishes.Length)];
        readonly static string selectedIngredient = ingredients[random.Next(ingredients.Length)];



        DFTService DFTService = new DFTService($"text=I would love to have a {selectedDish} with some {selectedIngredient}");

        [Test]
        public void WhenISendARequestWith_TwoFoodItems_IExpextToGetAResponseWith_2BodyItems()
        {
            Assert.That(DFTService.GetNumberOfResponseBodyItems, Is.EqualTo(2));
        }

        [Test]
        public void WhenIsendAnIngredientInTheBodyRequest_TheIngredientIsTaggedCorrectly()
        {
            Assert.That(DFTService.CheckIfFoodItemIsTaggedCorrectly(selectedIngredient, "ingredient"));
        }

        [Test]
        public void WhenIsendADishInTheBodyRequest_TheDishIsTaggedCorrectly()
        {
            Assert.That(DFTService.CheckIfFoodItemIsTaggedCorrectly(selectedDish, "dish"));
        }

        [Test]
        public void WhenIsendAnIngredientInTheBodyRequest_TheIngredientIsNamedCorrectly()
        {
            Assert.That(DFTService.CheckIfFoodItemIsAnnotatedCorrectly(selectedIngredient, "ingredient"));
        }
        [Test]
        public void WhenIsendADishInTheBodyRequest_TheDishIsNamedCorrectly()
        {
            Assert.That(DFTService.CheckIfFoodItemIsAnnotatedCorrectly(selectedDish, "dish"));
        }

        [Test]
        public void TheImageAttributeOfTheResponseForeachBodyItemIsNotNull()
        {
            Assert.That(DFTService.CheckIfImageAttributeIsNull(),Is.False);
        }
    }
}
