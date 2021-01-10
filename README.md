# API Testing Project
## Table of Contents
- [API Testing Project](#api-testing-project)
  - [Project Overview ](#project-overview)
  - [Project Goals](#project-goals)
  - [User Guide](#user-guide)
      - [Prerequisites](#prerequisites)
      - [Class Diagram](#class-diagram)
  - [Sprint Breakdowns](#sprint-breakdowns)
    - [Sprint 1](#sprint-1)
      - [Sprint Review](#sprint-review)
      - [Sprint Retrospective](#sprint-retrospective)
      - [Sprint Goals](#sprint-goals)

## Project Overview
The aim of this project is to create a test framework for the 'Detect food in text' and 'Extract Recipe From Website' services of the 'Recipe - Food - Nutrition' API which can be found here: https://rapidapi.com/spoonacular/api/recipe-food-nutrition/endpoints. 


## Project Goals
The framework will have:

* Tests that test all response data
* At least 2 requests tested
* Github Repo that utilises commits and dev branches
* A project board with a scrum framework
* Detailed README.md that explains how to use framework
* Readme should include instructions on possible further expansion
* Readme should include a class diagram



## User Guide

#### Prerequisites

You must obtain your own personal API key from RapidAPI in order to use this testing framework, please follow the following link https://rapidapi.com/spoonacular/api/recipe-food-nutrition/endpoints. 

This key must be placed in app.config file in the following line. 

```xml
<add key="api_key" value="INSERT KEY HERE" />
```

#### Detect Food In Text

Detect Food In Text is a POST call that returns all the ingredients and dishes contained in a request 

In order for this request to be feasible you need to  

1. Instantiate a new RestRequest with the request URL and the request method. 

   1. Example

      ```csharp
      var request = new RestRequest(RecipeConfigReader.BaseUrl+ "/food/detect", Method.POST);
      ```


2. Add a header that includes your API key that you obtained earlier From RapidApi. [See Prerequisites](####Prerequisites)  

   1. Example:

      ```csharp
      request.AddHeader("x-rapidapi-key",RecipeConfigReader.APIKey);
      ```

      

3. Optional: Add a Header that specifies the content type of the body request

   1. Example

      ```csharp
      request.AddHeader("content-type", "application/x-www-form-urlencoded")
      ```

1. Add a body parameter of type: application/x-www-form-urlencoded
   1. Example:
   
        ```csharp 
        string exampleRequestBody ="text=This is an Example Food Dish and an Example Food Ingredient"
        request.AddParameter("application/x-www-form-urlencoded", exampleRequestBody, ParameterType.RequestBody})
        ```


Detect Food In Text Full Post Request Example:

```csharp
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
```

In order to create new Tests, in your Test Classes, before creating your Test Cases, you sould instantiate a new DFTService and pass to the constructor the string representing the body of the request that you want to test.

Example:

```csharp
DFTService DFTService = new DFTService("text=I would love to have a pizza with some mushrooms");
```

#### Get Recipes

Get Recipes is a GET request that will extract the instructions/ingredients/dietary exclusions from a website.

The desired URL to extract data from can be placed in app.config  in the following line:

```xml
<add key="test_source_url" value="TEST SOURCE URL HERE"/>
```



The tests will need to be altered depending on the recipe being passed in.

The following test will need to be adapted if the recipe is not vegetarian.

```c#
public void RecipeIsVegetarianReturnsTrueBool()
{
	Assert.That(_ReturnedRecipe.CheckIfRecipeIsVegetarian());
}
```

The following test will have to be altered depending on how many steps the recipe being passed in has:

```c#
public void RecipeInstructionStepCountIs7()
{
    Assert.That(_ReturnedRecipe.InstructionsStepCount(), Is.EqualTo(7));
}
```



#### Class Diagram

![Class Diagram](https://github.com/GCarrell/API-Testing-Project/blob/dev/RecipeAPI_TestingFramework/RecipeAPI_TestingFramework/Images/ClassDiagram.png)




## Sprint Breakdowns

### Sprint 1
#### Sprint Review
By the end of Sprint 1 almost all of the User Stories in the backlog were completed. It was discovered that the API does not return a status code, which was the basis for two Testing User Stories, making them incompletable. It was decided that testing this wasn't necessary as if other tests passed then it was clear the response was returned successfully.

Tests were added that checked the response of both the 'Get Recipes' and 'Detect Food In Text' services. Tests were also added that tested the following methods:

* CheckIfRecipeIsVegetarian - checks if recipe is vegetarian
* InstructionsStepCount - returns number of instructions in the recipe
* GetNumberOfResponseBodyItems - Returns the number of the responded body items
* CheckIfFoodItemIsTaggedCorrectly - Returns true if the specified food Item is tagged correctly
* CheckIfImageAttributeIsNull - Returns True if an immage Attribute is null
* CheckIfFoodItemIsAnnotatedCorrectly -  Returns True if the specified food Item is annotated Correctly

#### Sprint Retrospective
In terms of workload the sprint was planned well. Problems did arise with pushing and pulling with Github, with one group member pulling changes over the top of their dev branch and having to start again, this could have been countered by committing the personal dev branch to Github just to make sure there was a back-up before pulling the most recent commit.
#### Sprint Goals
  - [x] Prepare Config Reader File
  - [x] Food In Text Data Root Class
  - [x] Food In Text Call Manager Class
  - [x] Food In Text Call Manager Method
  - [x] Food In Text Data Transfer Object
  - [x] Get Recipes Data Root Class
  - [x] Get Recipes Call Manager Class
  - [x] Get Recipes Call Manager Method
  - [ ] Food In Text Status Response Test
  - [ ] Get Recipes Status Response Test
  - [x] Food In Text Desired Food Item Test
  - [x] Get Recipes Desired Recipe Test
  - [x] Creating a Solutions Items Folder
  - [x] Creating a Folder that contains the files for the "Detect food in text" API request.
  - [x] Creating a Folder that contains the files which handle the data from the "Detect Food In Text" API request
  - [x] Creating a Folder that contains the files which handle the HTTP calls for the "Detect Food In Text" API request
  - [x] Creating a Folder that contains the files for the "Get Recipes" API request.
  - [x] Creating a Folder that contains the files which handle the data from the "Get Recipes" API request
  - [x] Creating a Folder that contains the files which handle the HTTP calls for the "Get Recipes" API request
  - [x] Complete User Story 2.4
  - [x] Creating a Folder that contains the test files for the "Get Recipes" API request
  - [x]  Commit changes  after the arrange is complete
  - [x] Update ReadMe



