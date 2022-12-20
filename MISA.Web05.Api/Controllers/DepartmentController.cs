using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web05.Core;
using MISA.Web05.Core.Exceptions;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;

namespace MISA.Web05.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class DepartmentController : BaseController<Department>
    {
        #region Constructor
        IDepartmentService _service;
        IDepartmentRepository _repository;
        /// <summary>
        /// Author: THBAC (11/7/2022 - 22:22)
        /// Hàm tạo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repository"></param>
        public DepartmentController(IDepartmentService service, IDepartmentRepository repository):base(service, repository)
        {
            _service = service;
            _repository = repository;
        }
        #endregion
    }

}
