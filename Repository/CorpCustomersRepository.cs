using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Contracts;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;

namespace Repository
{    // ESTA ES LA LOGICA QUE UTILIZO 
    public class CorpCustomersRepository : RepositoryBase<CorpCustomers>, ICustomersRepository
    {

        public class Encrypt
        {
            public static string GetSHA256(string str)
            {
                SHA256 sha256 = SHA256.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha256.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }

        public CorpCustomersRepository(proyect_weightContext ProyectContext) 
            : base(ProyectContext) {}

        public IEnumerable<CorpCustomers> GetAllCorpCustomers()
        {
                return FindAll()
                    .OrderBy(cc => cc.IdCustomers).ToList();
        }
        public CorpCustomers GetCustomerById(int IdCustomers)
        {
            return FindByCondition(cc => cc.IdCustomers.Equals(IdCustomers))
                    .DefaultIfEmpty(new CorpCustomers())
                    .FirstOrDefault();
        }

        public CorpCustomersExtended GetCustomerWithDetails(int IdCustomers)
        {
            return new CorpCustomersExtended(GetCustomerById(IdCustomers))
            {
                WeightControl = Proyect_weightContext.WeightControl
                        .Where(cwd => cwd.IdCustomers == IdCustomers)
            };
        }

        public void CreateCustomer(CorpCustomers customer)
        {
            customer.IdCustomers = customer.IdCustomers;
            customer.FirstName = customer.FirstName;
            customer.LastName = customer.LastName;
            customer.Email = customer.Email;
            customer.DateOfBirth = customer.DateOfBirth;
            customer.Password = Encrypt.GetSHA256(customer.Password);
            customer.Status = customer.Status = 1;
            customer.UserModify = customer.FirstName;
            customer.DateModify = customer.DateModify = DateTime.Today;
            customer.PasswordAttempts = customer.PasswordAttempts = 0;
            Create(customer);
            Save();

        }

        public void UpdateCustomer(CorpCustomers dbCustomer, CorpCustomers customer)
        {
            dbCustomer.Map(customer);
            Update(dbCustomer);
        }

        public void DeleteCustomer(CorpCustomers customer) 
        {
            Delete(customer);
        }
    }
}