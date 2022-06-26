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
    public class DepartmentController : BaseController
    {

        private readonly IManager<Dept> _manager;

        private readonly IMapper _mapper;

        private readonly ILogger<DepartmentController> _logger;

        public IConfiguration Configuration { get; }   

        public DepartmentController(IManager<Dept> manager, 
            IMapper mapper, 
            ILogger<DepartmentController> logger, 
            IConfiguration configuration)
        {
            _manager = manager;
            _mapper = mapper;
            _logger = logger;
            Configuration = configuration;
        }




        // GET: api/<DepartmentController>
        [Route("All")]
        [HttpGet]
        public ServiceResponse<List<DeptVM>> Get()
        {

            var response = new ServiceResponse<List<DeptVM>>();

            try
            {

                var data = _manager.GetList();

                if(data != null && data.Count > 0)
                {
                    List<DeptVM> objDeptList = new List<DeptVM>();

                    foreach (var Dept in data)
                    {
                        DeptVM objDeptInfo = _mapper.Map<DeptVM>(Dept);

                        objDeptList.Add(objDeptInfo);
                    }
                    response.Model = objDeptList;
                    response.Success = true;
                    response.Message = "Department List";
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

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public ServiceResponse<DeptVM> Get(int id)
        {
            var response = new ServiceResponse<DeptVM>();

            try
            {
                var data = _manager.Get(id);

                if(data != null)
                {
                    DeptVM objDeptInfo = _mapper.Map<DeptVM>(data);

                    response.Model = objDeptInfo;
                    response.Success = true;
                    response.Message = "Department Info";
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

        //POST api/<DepartmentController>
        [HttpPost]
        public Task<ServiceResponse<DeptVM>> Post([FromBody] DeptVM Deptvm)
        {

            var response = new ServiceResponse<DeptVM>();

            try
            {
                Dept model = _mapper.Map<Dept>(Deptvm);
                var data = _manager.Create(model);

                DeptVM objDepts = _mapper.Map<DeptVM>(data);
                response.Model = objDepts;
                response.Success = true;
                response.Message = "Departments created successfully";

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Looks like something isn’t quite right. Please try again.";  //Message = GetErrorMessageDetail(ex);
                //response = StatusCode(StatusCodes.Status500InternalServerError, $"Error in creating Hotels login details. Please try again.");
            }

            return Task.FromResult(response);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public ServiceResponse<DeptVM> Put(int id, [FromBody] DeptVM model)
        {
            var response = new ServiceResponse<DeptVM>();

            try
            {
                Dept objDepts = _manager.Get(id);
                if(objDepts != null)
                {
                    _manager.Update(_mapper.Map<DeptVM, Dept>(model, objDepts));

                    response.Model = model;
                    response.Success = true;
                    response.Message = "Department updated successfully";
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

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public ServiceResponse<bool> Delete(int id)
        {
            var response = new ServiceResponse<bool>();

            try
            {
                _manager.Delete(id);

                response.Model = true;
                response.Success = true;
                response.Message = "Department deleted successfully";
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
