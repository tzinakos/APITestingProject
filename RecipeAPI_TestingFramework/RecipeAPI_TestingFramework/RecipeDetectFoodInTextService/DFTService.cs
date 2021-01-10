using System;

namespace RecipeAPI_TestingFramework
{
    public class DFTService
    {
        public FoodInTextCallManager FoodInTextCallManager { get; set; } = new FoodInTextCallManager();

        public FoodInTextDTO FoodInTextDTO { get; set; } = new FoodInTextDTO();

        public string DetectedFood { get; set; }

        public DFTService(string requestBody)
        {
            DetectedFood = FoodInTextCallManager.GetDetectedFood(requestBody);

            FoodInTextDTO.Desirialize(DetectedFood);
        }

        public int GetNumberOfResponseBodyItems()
        {
            return FoodInTextDTO.FoodInTextRoot.annotations.Length;
        }

        public bool CheckIfFoodItemIsTaggedCorrectly(string foodItem, string tag)
        {
            bool result = false;
            
                foreach (var item in FoodInTextDTO.FoodInTextRoot.annotations)
                {
                    if (item.annotation == foodItem)
                    {
                       result= item.tag == tag;
                    }
                }
            return result;
        }

        public bool CheckIfImageAttributeIsNull()
        {
            bool result = true;
            foreach (var item in FoodInTextDTO.FoodInTextRoot.annotations)
            {
                result = item.image == null;
            }
            return result;
        }
        public bool CheckIfFoodItemIsAnnotatedCorrectly(string foodItemAnnotation, string tag)
        {
            bool result = false;
            foreach (var item in FoodInTextDTO.FoodInTextRoot.annotations)
            {
                if (item.tag == tag)
                {
                    result = item.annotation == foodItemAnnotation;
                }
            }
            return result;
        }


    }
}
