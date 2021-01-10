using RestSharp;
namespace RecipeAPI_TestingFramework
{
    public class FoodInTextCallManager
    {
        private RestClient Client = new RestClient();
        public string GetDetectedFood(string requestBody)
        {
            var request = new RestRequest(RecipeConfigReader.BaseUrl+ "/food/detect", Method.POST);

            request.AddHeader("x-rapidapi-key",RecipeConfigReader.APIKey);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded", requestBody,ParameterType.RequestBody);
            var requestContent= Client.Execute(request);

            return requestContent.Content;
        }
    }
}
