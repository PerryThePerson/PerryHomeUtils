using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImageSearchLib;


namespace BillPayer.Models
{
    public class Product
    {
        public int ID { get; set; }
        public String Description { get; set; }
      
        public String GetImage(String ProductDescription)
        {
            String ImageURL = "";

            ImageURL = GoogleImageSearch.SearchImage(ProductDescription);

            return ImageURL;
        }
        
    }
}