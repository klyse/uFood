using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.Infrastructure.OpenDataHub.ModelExtensions
{
    public static class GastronomyExtension
    {
        public static  List<Dish> GetDishesByNutrient(this Gastronomy gastronomy, Nutrient nutrient)
        {
            List<Dish> disesh = new List<Dish>();


            return disesh;
        }
    }
}
