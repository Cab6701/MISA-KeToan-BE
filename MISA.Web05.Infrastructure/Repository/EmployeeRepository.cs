using Dapper;
using MISA.Web05.Core;
using MISA.Web05.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Methods
        /// <summary>
        /// Author: THBAC (11/7/2022 - 20h58)
        /// Hàm tạo
        /// </summary>
        public EmployeeRepository()
        {
            
        }
        /// <summary>
        /// Author: THBAC (22/7/2022)
        /// Hàm lấy thông tin toàn bộ nhân viên
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Employee> Get()
        {
            //Khởi tạo kết nối:
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = "Proc_GetEmployee";
                var data = MySqlConnection.Query<Employee>(sql, commandType: System.Data.CommandType.StoredProcedure);
                return data;
            }
        }
        /// <summary>
        /// Author: THBAC (11/7/2022 - 20h58)
        /// Hàm kiểm tra xem mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>True: Đã tồn tại, False: Chưa tồn tại</returns>
        public bool CheckEmployeeCodeExits(string employeeCode)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";
                var parametes = new DynamicParameters();
                parametes.Add("@EmployeeCode", employeeCode);
                var res = MySqlConnection.QueryFirstOrDefault(sql: sql, param: parametes);
                if(res == null)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Author: THBAC (11/7/2022 - 20h58)
        /// Phân trang
        /// </summary>
        /// <returns>Object chứa thông tin số trang, số bản ghi, tổng số bản ghi</returns>
        public Object GetPaging(int pageIndex, int pageSize, string? fillter = "")
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetEmployeePaging";
                DynamicParameters parameters=new DynamicParameters();
                parameters.Add("@b_Filter", fillter);
                parameters.Add("@b_PageIndex", pageIndex);
                parameters.Add("@b_PageSize", pageSize);
                parameters.Add("@b_TotalRecord", direction:System.Data.ParameterDirection.Output);
                parameters.Add("@b_RecordStart", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@b_RecordEnd", direction: System.Data.ParameterDirection.Output);

                var employees = MySqlConnection.Query<Employee>(sql,param:parameters, commandType: System.Data.CommandType.StoredProcedure);
                int totalRecord = parameters.Get<int>("@b_TotalRecord");
                int recordStart = parameters.Get<int>("@b_RecordStart");
                int recordEnd = parameters.Get<int>("@b_RecordEnd");
                return new
                {
                    TotalRecord=totalRecord,
                    RecordStart=recordStart,
                    RecordEnd=recordEnd,
                    Data = employees,
                };
            }
        }
        /// <summary>
        /// Author: THBAC (2/7/2022 - 14:46)
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        public string GetNewEmployeeCode()
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetNewEmployeeCode";
                var newcode = MySqlConnection.QueryFirst<string>(sql:sql, commandType:System.Data.CommandType.StoredProcedure);
                return newcode;

            }
        }
        #endregion
    }
}
