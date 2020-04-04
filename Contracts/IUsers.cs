using Entities.ExtendedModels;
using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUsers
    {
        CorpCustomersExtended Authenticate(string Email, string Password);
    }
}
