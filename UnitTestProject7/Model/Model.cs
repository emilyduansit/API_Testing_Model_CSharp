using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject7.Model
{  
    
    //<summary>
    //Reponse Fees class for ListingFeeTier
    //<summary>
    public class ListingFeeTier
    {
        public int MinimumTierPrice { get; set; }
        public double FixedFee { get; set; }
    }
    //<summary>
    //Response root object for the Fee item
    //<summary>
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
    //<summary>
    //Response root object for the Promotion item
    //<summary>
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
    //<summary>
    //Response Model class for the root object
    //<summary>
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
}
