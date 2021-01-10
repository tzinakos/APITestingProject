using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;


namespace RecipeAPI_TestingFramework
{
    class GetRecipesCallManager
    {
        private readonly IRestClient _client;
        public GetRecipesCallManager()
        {
            _client = new RestClient(RecipeConfigReader.BaseUrl);
        }
        public string GetRecipes()
        {
            var request = new RestRequest("/recipes/extract");
            request.AddHeader("x-rapidapi-key", RecipeConfigReader.APIKey);
            request.AddParameter("url", RecipeConfigReader.TestSourceUrl);
            var response = _client.Get(request);

            return response.Content;
        }
    }
}
