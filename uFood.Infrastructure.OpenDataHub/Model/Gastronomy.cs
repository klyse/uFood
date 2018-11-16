using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.OpenDataHub.Model
{
    public class Gastronomy
    {
        public string ID { get; set; }

        public string ForeginID { get; set; }

        public IEnumerable<Dish> Dishes { get; set; }

    }
}
