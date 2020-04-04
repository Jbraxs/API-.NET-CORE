using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICustomersRepository CorpCustomers { get; }
        IWeightControlRepository WeightControl { get; }
        void Save();
    }
}
