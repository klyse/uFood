using System;
using System.Collections.Generic;
using System.Text;

namespace uFood.Infrastructure.Models.Food
{
    public class Ingredient
    {
        public double Quantity { get; set; }

        public Nutrient Nutrient { get; set; }
    }
}
