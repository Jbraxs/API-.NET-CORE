using Contracts;
using Entities.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private proyect_weightContext _repoContext;
        private ICustomersRepository _cc;
        private IWeightControlRepository _wc;


        public ICustomersRepository CorpCustomers
        {
            get
            {
                if (_cc == null)
                {
                    _cc = new CorpCustomersRepository(_repoContext);
                }

                return _cc;
            }
        }

        public IWeightControlRepository WeightControl
        { 
            get
            {
                if (_wc == null)
                { 
                    _wc = new WeightControlRepository(_repoContext);
                }

                return _wc;
            }
        }

        public RepositoryWrapper(proyect_weightContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
