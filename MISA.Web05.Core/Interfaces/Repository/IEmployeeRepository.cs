using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Interfaces.Repository
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        #region Methods

        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:09)
        /// Kiểm tra mã nhân viên đã tồn tại trong hệ thống chưa
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true - đã tồn tại; false - chưa có trong hệ thống</returns>
        bool CheckEmployeeCodeExits(string employeeCode);

        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:010)
        /// Phân trang
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="fillter"></param>
        /// <returns></returns>
        Object GetPaging( int pageIndex, int pageSize, string? fillter);
        /// <summary>
        /// Author: THBAC (14/7/2022)
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Mã nhân viên mới</returns>
        string GetNewEmployeeCode();
        #endregion
    }
}
