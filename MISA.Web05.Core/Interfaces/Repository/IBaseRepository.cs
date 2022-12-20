using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Interfaces.Repository
{
    public interface IBaseRepository<MISAEntity>
    {
        #region Properties
        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:10)
        /// Hàm mẫu lấy dữ liệu
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: Trinh Hoai Bac(29/6/2022)
        IEnumerable<MISAEntity> Get();
        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:10)
        /// Hàm mẫu lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        MISAEntity Get(Guid id);
        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:17)
        /// Hàm mẫu thêm dữ liệu
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int Insert(MISAEntity employee);
        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:20)
        /// Hàm mẫu sửa dữ liệu
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int Update(MISAEntity employee);
        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:15)
        /// Hàm mẫu xoá dữ liệu
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        int Delete(Guid employeeId);
        #endregion
    }
}
