using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestSharpExample
{
    public class ListingFeeTier
    {
        public int MinimumTierPrice { get; set; }
        public double FixedFee { get; set; }
    }

    public class Fees
    {
        public double Bundle { get; set; }
        public double EndDate { get; set; }
        public double Feature { get; set; }
        public double Gallery { get; set; }
        public double Listing { get; set; }
        public double Reserve { get; set; }
        public double Subtitle { get; set; }
        public double TenDays { get; set; }
        public List<ListingFeeTier> ListingFeeTiers { get; set; }
        public double SecondCategory { get; set; }
    }

    public class Promotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int MinimumPhotoCount { get; set; }
        public double OriginalPrice { get; set; }
        public bool Recommended { get; set; }
    }

    public class RootObject
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool CanListAuctions { get; set; }
        public bool CanListClassifieds { get; set; }
        public bool CanRelist { get; set; }
        public string LegalNotice { get; set; }
        public int DefaultDuration { get; set; }
        public List<int> AllowedDurations { get; set; }
        public Fees Fees { get; set; }
        public int FreePhotoCount { get; set; }
        public int MaximumPhotoCount { get; set; }
        public bool IsFreeToRelist { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<object> EmbeddedContentOptions { get; set; }
        public int MaximumTitleLength { get; set; }
        public int AreaOfBusiness { get; set; }
        public int DefaultRelistDuration { get; set; }
    }
    [TestClass]
    public class CarbonTest
    {
        [TestMethod]
        public void NameTest()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("https://api.tmsandbox.co.nz/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("/v1/Categories/6327/Details.json?catalogue=false", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            RootObject example = new JsonDeserializer().Deserialize<RootObject>(restResponse);

            Assert.AreEqual(example.Name, "Carbon credits"); 
        }

        [TestMethod]
        public void CanrelistTest()
        {
            //Creating Client connection 
            RestClient restClient = new RestClient("https://api.tmsandbox.co.nz/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("/v1/Categories/6327/Details.json?catalogue=false", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            RootObject example = new JsonDeserializer().Deserialize<RootObject>(restResponse);

            Assert.IsTrue(example.CanRelist);
        }

        [TestMethod]
        public void PromotionTest()
        {
            
            //Creating Client connection 
            RestClient restClient = new RestClient("https://api.tmsandbox.co.nz/");

            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("/v1/Categories/6327/Details.json?catalogue=false", Method.GET);

            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Extracting output data from received response
            RootObject example = new JsonDeserializer().Deserialize<RootObject>(restResponse);

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
