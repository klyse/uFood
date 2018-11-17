using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Messages
{
    public class NutrientCheckResult
    {
        public bool IsEvilForYou { get; set; }

        public string Message { get; set; }

        public Nutrient AlternativeNutrient { get; set; }
    }
}
