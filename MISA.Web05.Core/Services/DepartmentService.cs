using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Web05.Core.Exceptions;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;

namespace MISA.Web05.Core.Services
{
    public class DepartmentService :BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _repository;
        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public DepartmentService(IDepartmentRepository repository):base(repository)
        {
            _repository = repository;
        }

    }
}
