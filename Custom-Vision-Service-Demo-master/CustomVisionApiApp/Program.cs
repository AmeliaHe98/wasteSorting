using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

namespace CSPredictionSample
{
    internal static class Program
    {
        private static void Main()
        {
            //Console.Write("Enter image file path: ");
            string imageFilePath = "/Users/Amelia/Downloads/IMG_0831.JPG";

            MakePredictionRequest(imageFilePath).Wait();

            Console.WriteLine("\n\n\nHit ENTER to exit...");
            Console.ReadLine();
        }

        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        private static async Task MakePredictionRequest(string imageFilePath)
        {
            var client = new HttpClient();
            // Request headers - replace this example key with your valid subscription key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "e0ce1a50ac584286810648dcb87d986a");
            // Prediction URL - replace this example URL with your valid prediction URL.
            string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/image?iterationId=2";
            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored image.
            //byte[] byteData = GetImageAsByteArray(imageFilePath);
            byte[] byteData = Encoding.UTF8.GetBytes("{Url:http://cdnimg2.webstaurantstore.com/images/products/extra_large/12689/310269.jpg}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(url, content);

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}