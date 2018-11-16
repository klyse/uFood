using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.ModelExtensions
{
    public static class ReciptExtension
    {
        public static double CalculateTotalEnergy(this Recipe recipe)
        {
            double energy = 0;
            
            // TODO
            
            return energy;
        }

        public static double CalculateTotalFat(this Recipe recipe)
        {
            double fat = 0;

            // TODO

            return fat;
        }

        public static double CalculateTotalProteins(this Recipe recipe)
        {
            double protein = 0;

            // TODO

            return protein;
        }
    }
}
