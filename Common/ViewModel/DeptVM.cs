using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class DeptVM : BaseEntityVM
    {
        public int DeptId { get; set; }

        public string? DeptName { get; set; }
    }
}
