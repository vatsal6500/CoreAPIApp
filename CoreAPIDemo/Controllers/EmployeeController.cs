using AutoMapper;
using Common.Models;
using Common.ViewModel;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using WebAPICore.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IManager<Emp> _manager;
        private readonly IManager<Dept> _managerDept;

        private readonly IMapper _mapper;

        private readonly ILogger<Emp> _logger;   

        public IConfiguration Configuration { get; }

        public EmployeeController(IManager<Emp> manager, 
            IMapper mapper, 
            ILogger<Emp> logger, 
            IConfiguration configuration,
            IManager<Dept> managerdept)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            Configuration = configuration;
            _managerDept = managerdept;
        }




        // GET: api/<EmployeeController>
        [Route("All")]
        [HttpGet]
        public ServiceResponse<List<EmpVM>> Get()
        {
            var response = new ServiceResponse<List<EmpVM>>();

            try
            {
                var data = _manager.GetList();
                var deptData = _managerDept.GetList();

                if (data != null && data.Count > 0)
                {
                    List<EmpVM> objEmpList = new List<EmpVM>();

                    foreach (var dept in deptData)
                    {
                        foreach (var Emp in data.Where(t => t.DeptId == dept.DeptId))
                        {
                            EmpVM objEmpInfo = _mapper.Map<EmpVM>(Emp);
                            objEmpList.Add(objEmpInfo);
                        }
                    }
                    response.Model = objEmpList;
                    response.Success = true;
                    response.Message = "Employee List";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unable to fetch Deptrtment list, Please Try again.";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in fetching all CityMaster. Please try again.");
            }

            return response;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ServiceResponse<EmpVM> Get(int id)
        {
            var response = new ServiceResponse<EmpVM>();

            try
            {
                var data = _manager.Get(id);

                if(data != null)
                {
                    EmpVM objEmpInfo = _mapper.Map<EmpVM>(data);

                    response.Model = objEmpInfo;
                    response.Success = true;
                    response.Message = "Employee Info";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Unable to fetch Hotels information for given Id, Please try with correct Id";
                }

            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in fetching Hotels details by id. Please try again.");
            }

            return response;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public Task<ServiceResponse<EmpVM>> Post([FromForm] EmpVM Empvm)
        {
            var response = new ServiceResponse<EmpVM>();

            try
            {
                Emp model = _mapper.Map<Emp>(Empvm);
                var data = _manager.Create(model);

                EmpVM objEmps = _mapper.Map<EmpVM>(data);
                response.Model = objEmps;
                response.Success = true;
                response.Message = "Employee created successfully";
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating Hotels login details. Please try again.");
            }

            return Task.FromResult(response);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ServiceResponse<EmpVM> Put(int id, [FromBody] EmpVM model)
        {
            var response = new ServiceResponse<EmpVM>();

            try
            {
                Emp objEmps = _manager.Get(id);

                if(objEmps != null)
                {
                    _manager.Update(_mapper.Map<EmpVM, Emp>(model, objEmps));

                    response.Model = model;
                    response.Success = true;
                    response.Message = "Employee updated successfully";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Please enter valid Hotels id.";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in deleting Hotels. Please try again.");
            }

            return response;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ServiceResponse<bool> Delete(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                _manager.Delete(id);

                response.Model = true;
                response.Success = true;
                response.Message = "Employee deleted successfully";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in deleting Hotels. Please try again.");
            }

            return response;
        }
    }
}
