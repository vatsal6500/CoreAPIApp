using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class RepositoryBase
    {
        protected readonly RepositoryBase _repository;

        public RepositoryBase(RepositoryBase repository)
        {
            _repository = repository;
        }
    }
}
