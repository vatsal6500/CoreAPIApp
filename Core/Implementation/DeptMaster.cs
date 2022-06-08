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
    public class DeptMaster : IManager<Dept>
    {

        private IRepository<Dept> _repository { get; set; }

        public DeptMaster(IRepository<Dept> repository)
        {
            _repository = repository;
        }

        public Dept Create(Dept item)
        {
            return _repository.Create(item);
        }

        public void Delete(int id)
        {
            _repository.DeleteById(id);
        }

        public Dept Get(int id)
        {
            return _repository.GetById(id);
        }

        public List<Dept> GetList()
        {
            return _repository.Table.ToList();
        }

        public void Update(Dept item)
        {
            _repository.Update(item);
        }

        public bool UpdateStatus(int Id)
        {
            return _repository.UpdateStatusById(Id);
        }
    }
}
