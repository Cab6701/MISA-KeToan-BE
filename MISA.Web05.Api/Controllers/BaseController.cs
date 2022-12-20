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

    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Constructor
        IBaseService<MISAEntity> _service;
        IBaseRepository<MISAEntity> _repository;
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Hàm tạo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repository"></param>
        public BaseController(IBaseService<MISAEntity> service, IBaseRepository<MISAEntity> repository)
        {
            _service = service;
            _repository = repository;
        }
        #endregion

        #region HttpGet
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Lấy toàn bộ thông tin
        /// </summary>
        /// <returns>Danh sách thông tin</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var employees = _repository.Get();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Lấy thông tin bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>thông tin bản ghi theo ID</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            try
            {
                var employees = _repository.Get(id);
                return Ok(employees);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }

#endregion

        #region HttpPost
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Thêm một bản ghi mới
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(MISAEntity employee)
        {
            try
            {
                var res = _service.InsertService(employee);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion

        #region HttPut
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Bản ghi</returns>
        [HttpPut]
     
        public IActionResult Put(MISAEntity employee)
        {
            try
            {
                var res = _service.UpdateService(employee);
                return Ok(res);
            }
            catch (Exception ex)
            {

                return HandleException(ex);
            }
        }
        #endregion

        #region HttpDelete
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Xoá thông tin bản ghi theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(Guid employeeId)
        {
            try
            {
                var res = _repository.Delete(employeeId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:02)
        /// Hàm xử lý lỗi
        /// </summary>
        /// <param name="ex"></param>
        /// <returns>StatusCode</returns>
        protected IActionResult HandleException(Exception ex)
        {

            if (ex is MISAValidateException)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    data = ex.Data,
                    userMsg = ex.Message

                };
                return StatusCode(400, res);
            }
            else
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = MISA.Web05.Core.Resources.Resource.ResourceManager.GetString($"ErrorException_{Common.LanguageCode};")

                };
                return StatusCode(500, res);
            }
        }
        #endregion
    }

}
