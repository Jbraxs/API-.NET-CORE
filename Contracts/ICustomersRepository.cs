using Entities.Models;
using Entities.ExtendedModels;
using System;
using System.Collections.Generic;


namespace Contracts
{ // Se podria decir que es como las rutas
    public interface ICustomersRepository : IRepositoryBase<CorpCustomers>
    {
        IEnumerable<CorpCustomers> GetAllCorpCustomers();
        CorpCustomers GetCustomerById(int IdCustomers);
        CorpCustomersExtended GetCustomerWithDetails(int IdCustomers);
        void CreateCustomer(CorpCustomers customer);
        void UpdateCustomer(CorpCustomers dbCustomer, CorpCustomers customer);
        void DeleteCustomer(CorpCustomers customer);
    }
}
