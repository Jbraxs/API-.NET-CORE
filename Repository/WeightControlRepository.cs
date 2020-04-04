using Contracts;
using Entities.Extensions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{   // ESTA ES LA LOGICA QUE UTILIZO 
    public class WeightControlRepository : RepositoryBase<WeightControl>, IWeightControlRepository
    {
        public WeightControlRepository(proyect_weightContext ProyectContext)
            : base(ProyectContext) {}

        public IEnumerable<WeightControl> GetAllWeightControls() 
        {
            return FindAll()
                .OrderBy(wc => wc.IdWeight).ToList();
        }

        public WeightControl GetWeightControlById(int IdWeight)
        {
            return FindByCondition(wc => wc.IdWeight.Equals(IdWeight))
                    .DefaultIfEmpty(new WeightControl())
                    .FirstOrDefault();
        }

        public void CreateWeight(WeightControl weight)
        {
            weight.Weight = weight.Weight;
            weight.Imc = weight.Imc;
            weight.DateWeight = weight.DateWeight;
                //= DateTime.Today;
            Create(weight);
            Save();
        }

        public void UpdateWeight(WeightControl dbWeightControl, WeightControl weight)
        {
            dbWeightControl.Map(weight);
            Update(dbWeightControl);
        }

        public void DeleteWeight(WeightControl weight)
        {
            Delete(weight);
        }
    }
}
    