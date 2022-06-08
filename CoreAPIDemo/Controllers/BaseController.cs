using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        #region Fields

        private readonly IHostingEnvironment _hostingEnvironment;

        public string DomainUrl => (HttpContext.Request.IsHttps ? "https://" : "http://") + HttpContext.Request.Host.Value + "/";

        public string WebRootPath;
        #endregion

        #region Ctor

        public BaseController()
        {

        }

        public BaseController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            WebRootPath = _hostingEnvironment.WebRootPath;
        }
        #endregion

        #region Methods
        protected string GetErrorMessageDetail(Exception ex)
        {
            return GetExceptionMessage(ex);
        }

        private string GetExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
                message += GetExceptionMessage(ex.InnerException);

            return message;
        }

        #endregion
    }
}
