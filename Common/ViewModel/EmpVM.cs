using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class EmpVM
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int DeptId { get; set; }

        public virtual DeptVM? Depts { get; set; }
    }
}
