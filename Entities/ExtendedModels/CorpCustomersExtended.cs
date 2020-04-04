using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ExtendedModels
{
    public class CorpCustomersExtended
    {
        public int IdCustomers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public string UserModify { get; set; }
        public DateTime DateModify { get; set; }
        public int PasswordAttempts { get; set; }
        public string Token { get; set; }

        public IEnumerable<WeightControl> WeightControl { get; set; }

        public CorpCustomersExtended()
        {
            WeightControl = new HashSet<WeightControl>();
        }

        public CorpCustomersExtended(CorpCustomers customers)
        {
            IdCustomers = customers.IdCustomers;
            FirstName = customers.FirstName;
            LastName = customers.LastName;
            Email = customers.Email;
            DateOfBirth = customers.DateOfBirth;
            Password = customers.Password;
            Status = customers.Status;
            UserModify = customers.UserModify;
            PasswordAttempts = customers.PasswordAttempts;
        }
    }
}
