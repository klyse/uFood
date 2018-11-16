using System;
using System.Collections.Generic;
using System.Text;

namespace uFood.Infrastructure.Models.Food
{
    public class Dish
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Recipe Recipe { get; set; }
    }
}
