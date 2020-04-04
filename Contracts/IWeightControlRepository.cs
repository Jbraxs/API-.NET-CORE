using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IWeightControlRepository: IRepositoryBase<WeightControl>
    {
        IEnumerable<WeightControl> GetAllWeightControls();
        WeightControl GetWeightControlById(int IdWeight); 
        void CreateWeight(WeightControl weight);
        void UpdateWeight(WeightControl dbWeightControl, WeightControl weight);
        void DeleteWeight(WeightControl weight);
    }
}
