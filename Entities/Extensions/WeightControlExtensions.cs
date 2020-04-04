using Entities.Models;

namespace Entities.Extensions
{
    public static class WeightControlExtensions
    {
        public static void Map(this WeightControl dbWeightControl, WeightControl weight)
        {
            dbWeightControl.Weight = weight.Weight;
            dbWeightControl.Imc = weight.Imc;
            dbWeightControl.DateWeight = weight.DateWeight;
        }
    }
}
