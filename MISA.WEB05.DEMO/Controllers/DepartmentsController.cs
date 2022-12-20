using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using MySqlConnector;
using MISA.WEB05.DEMO.Models;

namespace MISA.WEB05.DEMO.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        string _connectionString;
        MySqlConnection _mySqlConnection;

        public DepartmentsController()
        {
            _connectionString = "Host=3.0.89.182; " +
                    "Port=3306; " +
                    "Database = MISA.WEB05.THBAC; " +
                    "User Id = dev; " +
                    "Password=12345678";
            _mySqlConnection=new MySqlConnection(_connectionString);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               //Lấy đữ liệu
                var sqlQuery = "SELECT * FROM Department ";

                var departments = _mySqlConnection.Query<Department>(sqlQuery);

                //Trả dữ liệu về cho client
                return StatusCode(201,departments);
            }
            catch (Exception ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ MISA để được trợ giúp"

                };
                return StatusCode(500, res);
            }
        }
        [HttpGet("search")]
        public IActionResult GetById(Guid departmentId)
        {
            try
            {
               
               // Lấy đữ liệu
                //Khai báo câu lệnh truy vấn
                var sqlQuery = $"SELECT * FROM Department WHERE DepartmentId = '{departmentId.ToString()}'";

                var department = _mySqlConnection.QueryFirstOrDefault<Department>(sqlQuery);

                //Trả dữ liệu về cho client
                return Ok(department);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult Post(Department department)
        {
            try
            {
                //Validate dữ liệu
                //1. Tên phòng ban không được phép để trống

                if (string.IsNullOrEmpty(department.DepartmentName))
                {
                    var resService = new
                    {
                        userMsg= "Tên phòng ban không được phép để trống",
                    };
                    return BadRequest(resService);
                }

                //2. Tên phòng ban không được chứa từ Mạnh
                if (department.DepartmentName.Contains("Mạnh"))
                {
                    var resService = new
                    {
                        userMsg = "Tên phòng ban không được chứa từ Mạnh",
                    };
                    return BadRequest(resService);
                }

                //Khởi tạo DepartmentId
                department.DepartmentId = Guid.NewGuid();

                //Lấy đữ liệu
                //Khai báo câu lệnh truy vấn
                var sqlQuery = "Proc_InsertDepartment";

                var res = _mySqlConnection.Execute(sqlQuery,param: department, commandType: System.Data.CommandType.StoredProcedure);

                //Trả dữ liệu về cho client
                return Ok(res);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
