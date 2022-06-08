using AutoMapper;
using Common.Models;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Emp,EmpVM>().ReverseMap();
            CreateMap<Dept, DeptVM>().ReverseMap();
        }
    }
}
