using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Interfaces.Services
{
    /// <summary>
    /// Author: THBAC (12/7/2022 - 16:43)
    /// Hàm tạo
    /// </summary>
    public interface IEmployeeService : IBaseService<Employee>
    {
        #region Methods
        /// <summary>
        /// Author: THBAC (24/7/2022)
        /// Xuất khẩu
        /// </summary>
        /// <returns></returns>
        ExcelPackage Export();
        #endregion
    }
}
