using System;
using System.Collections.Generic;
using System.Text;

namespace uFood.Infrastructure.Models.Food
{
    public class Recipe
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

    }
}
