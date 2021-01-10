using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecipeAPI_TestingFramework
{

    public class FoodInTextRoot
    {
        public Annotation[] annotations { get; set; }
        public int processedInMs { get; set; }
    }

    public class Annotation
    {
        public string annotation { get; set; }
        public string tag { get; set; }
        public string image { get; set; }
    }

}