using Entities.Models;

namespace Entities.Extensions
{
    public static class CorpCustomerExtensions
    {
        public static void Map(this CorpCustomers dbCustomer, CorpCustomers customer)
        {
            dbCustomer.FirstName = customer.FirstName;
            dbCustomer.LastName = customer.LastName;
            dbCustomer.Email = customer.Email;
            dbCustomer.Password = customer.Password;
        }
    }
}
