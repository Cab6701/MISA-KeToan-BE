using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Interfaces.Services
{
    public  interface IBaseService<MISAEntity>
    {
        #region Methods
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:11)
        /// Thêm 1 bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int InsertService(MISAEntity employee);
        /// <summary>
        /// Author: THBAC (11/7/2022 - 21:12)
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int UpdateService(MISAEntity employee);
        #endregion
    }
}
