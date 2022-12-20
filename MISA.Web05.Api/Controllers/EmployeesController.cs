using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Web05.Core;
using MISA.Web05.Core.Exceptions;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;
using OfficeOpenXml;

namespace MISA.Web05.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController :BaseController<Employee>
    {
        #region Constructor
        IEmployeeRepository _repository;
        IEmployeeService _service;
        /// <summary>
        /// Author: THBAC (11/7/2022 - 9:02)
        /// Hàm tạo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="repository"></param>
        public EmployeesController(IEmployeeService service, IEmployeeRepository repository) :base(service, repository)
        {
            _repository = repository;
            _service = service;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:05)
        /// Hàm phân trang và lọc thông tin
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public IActionResult GetPaging(int pageIndex, int pageSize, string? filter)
        {
            try
            {
                var res = _repository.GetPaging(pageIndex, pageSize, filter);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        /// <summary>
        /// Author: THBAC (14/7/2022)
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Mã nhân viên mới</returns>
        [HttpGet("newEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            try
            {
                var res = _repository.GetNewEmployeeCode();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        /// <summary>
        /// Author: THBAC (24/7/2022)
        /// Xuất khẩu Excel
        /// </summary>
        /// <returns></returns>
        [HttpGet("Export")]
        public FileContentResult Export()
        {
            try
            {
                ExcelPackage employees = _service.Export();

                // ghi dũ liệu ra file
                using (var stream = new MemoryStream())
                {
                    employees.SaveAs(stream);
                    var content = stream.ToArray();

                    var file = new FileContentResult(content, "application/octet-stream");
                    file.FileDownloadName = "Danh_sach.xlsx";
                    return file;
                }
            }
            catch (Exception)
            {
                throw;
                //return (ActionResult)HandleException(ex);
            }
        }
        #endregion
    }

}
