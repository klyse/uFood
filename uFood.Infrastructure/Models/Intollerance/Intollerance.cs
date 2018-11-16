using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Intollerance
{
    public class Intollerance
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Nutrient> EvilNutrients { get; set; }

    }
}
