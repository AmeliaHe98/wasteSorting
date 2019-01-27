using System;
using System.IO;
//using System;
using Microsoft.Cognitive.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;

namespace CustomVisionSdkApp
{
    class Program
    {
        // Create the Api, passing in the training key



       
        static void Main(string[] args)
        {
            Guid projectId = Guid.Parse("[b02c1152-2060-43be-b687-c02945327bd2]");
            //string predictionKey = "[e0ce1a50ac584286810648dcb87d986a]";
            string imagePath = @"d:\sample.jpg";

            // Add your training & prediction key from the settings page of the portal
            string trainingKey = "<ab9d05f6280d4b4da17a2ce2a4258445";
            string predictionKey = "<e0ce1a50ac584286810648dcb87d986a>";
            private const string SouthCentralUsEndpoint = "https://southcentralus.api.cognitive.microsoft.com";


        MemoryStream testImage = new MemoryStream(File.ReadAllBytes(imagePath));


        CustomVisionPredictionClient endpoint = new CustomVisionPredictionClient()
        {
            ApiKey = predictionKey,
            Endpoint = SouthCentralUsEndpoint
        };



        //# Microsoft.Cognitive.CustomVision.Prediction.PredictionEndpointCredentials predictionEndpointCredentials 
        //var credentials= new PredictionEndpointCredentials(predictionKey);
        //PredictionEndpoint endpoint = new PredictionEndpoint(predictionEndpointCredentials);

        //ImagePredictionResultModel result = endpoint.PredictImage(projectId, testImage);

        // Loop over each prediction and write out the results
        //foreach (ImageTagPrediction prediction in result.Predictions)
        //{
        //    Console.WriteLine($"\t{prediction.Tag}: {prediction.Probability:P1}");
        //}

        //Console.ReadKey();

        // Make a prediction against the new project

        System.WriteLine("Making a prediction:");

        var result = endpoint.PredictImage(project.Id, testImage);

// Loop over each prediction and write out the results
foreach (var c in result.Predictions)
{
    Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
}
}
    }
