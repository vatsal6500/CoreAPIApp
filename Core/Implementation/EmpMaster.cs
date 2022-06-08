using Common.Models;
using Core.Interface;
using Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Implementation
{
    public class EmpMaster : IManager<Emp>
    {

        private IRepository<Emp> _repository { get; set; }

        public EmpMaster(IRepository<Emp> repository)
        {
            _repository = repository;
        }

        public Emp Create(Emp item)
        {
            return _repository.Create(item);
        }

        public List<Emp> GetList()
        {
            return _repository.Table.ToList();
        }

        public Emp Get(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(Emp item)
        {
            _repository.Update(item);
        }

        public bool UpdateStatus(int Id)
        {
            return _repository.UpdateStatusById(Id);
        }

        public void Delete(int id)
        {
            _repository.DeleteById(id);
        }
    }
}
