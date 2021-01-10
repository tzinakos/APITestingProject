using Newtonsoft.Json;

namespace RecipeAPI_TestingFramework
{
    public class FoodInTextDTO
    {
        public FoodInTextRoot FoodInTextRoot { get; set; }
        public void Desirialize(string detectedFood)
        {
            FoodInTextRoot = JsonConvert.DeserializeObject<FoodInTextRoot>(detectedFood);
        }
    }
}