using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Services
{
    public class PositionService : BaseService<Positions>, IPositionService
    {
        IPositionRepository _repository;
        /// <summary>
        /// Author: THBAC (25/6/2022 - 14:46)
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public PositionService(IPositionRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
