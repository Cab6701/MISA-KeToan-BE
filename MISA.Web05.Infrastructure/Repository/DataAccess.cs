using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core;

namespace MISA.Web05.Infrastructure.Repository
{
    /// <summary>
    /// Author: THBAC (25/6/2022 - 14:46)
    /// Hàm khởi tạo
    /// </summary>
    public class DataAccess : BaseRepository<Department>, IDepartmentRepository
    {
        
    }
}
