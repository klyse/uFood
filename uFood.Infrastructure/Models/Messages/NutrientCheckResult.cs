using System;
using System.Collections.Generic;
using System.Text;

namespace uFood.Infrastructure.Models.Messages
{
    public class NutrientCheckResult
    {
        public bool IsEvilForYou { get; set; }

        public string Message { get; set; }
    }
}
