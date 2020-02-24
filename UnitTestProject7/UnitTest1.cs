using System;
using UnitTestProject7.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestSharpExample
{
 
    [TestClass]
    public class CarbonTest
    {
        [TestMethod]
        public void ThreeValidation()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("https://api.tmsandbox.co.nz/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("/v1/Categories/6327/Details.json?catalogue=false", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            RootObject example = new JsonDeserializer().Deserialize<RootObject>(restResponse);

            //NameTest
            Assert.AreEqual(example.Name, "Carbon credits");

            //CanrelistTest
            Assert.IsTrue(example.CanRelist);

            //PromationTest
            String description = "";
            foreach (Promotion item in example.Promotions)
            {
                if (item.Name.Equals("Gallery"))
                    description = item.Description;
            }

            Assert.IsTrue(description.Contains("2x larger image"));
        }
        
    }
}
