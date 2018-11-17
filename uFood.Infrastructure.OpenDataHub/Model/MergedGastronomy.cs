using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.OpenDataHub.Model
{
    public class MergedGastronomy : Gastronomy
    {
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }
        public Position Position { get; set; }
        public List<string> DishesContainingNutrient { get; set; }
    }
}