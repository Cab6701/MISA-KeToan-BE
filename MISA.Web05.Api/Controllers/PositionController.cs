using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web05.Core;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;

namespace MISA.Web05.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class PositionController : BaseController<Positions>
    {
        #region Constructor
        IPositionService _service;
        IPositionRepository _repository;
        /// <summary>
        /// Author: THBAC (11/7/2022 - 10:34)
        /// Hàm tạo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repository"></param>
        public PositionController(IPositionService service, IPositionRepository repository):base(service, repository)
        {
            _service = service;
            _repository = repository;
        }
        #endregion
    }

}
