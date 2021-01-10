using System.Configuration;


namespace RecipeAPI_TestingFramework
{
    public static class RecipeConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string APIKey = ConfigurationManager.AppSettings["api_key"];
        public static readonly string TestSourceUrl = ConfigurationManager.AppSettings["test_source_url"];
    }
}
