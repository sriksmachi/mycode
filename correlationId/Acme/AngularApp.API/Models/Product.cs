using System;
using System.Collections.Generic;

namespace AngularApp.API.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal? Price { get; set; }
        public string ReleaseDate { get; set; }
        public string Description { get; set; }
        public double? StarRating { get; set; }
        public string ImageUrl { get; set; }
    }
}
