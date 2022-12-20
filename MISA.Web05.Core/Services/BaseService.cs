using MISA.Web05.Core.Exceptions;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Core.Services
{
    public class BaseService<MISAEntity>:IBaseService<MISAEntity>
    {
        #region Properties

        IBaseRepository<MISAEntity> _repository;
        protected List<string> ErrorValidateMsgs;
        protected bool IsValid = true;
        #endregion

        #region Constructor
        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public BaseService(IBaseRepository<MISAEntity> repository)
        {
            _repository = repository;
            ErrorValidateMsgs = new List<string>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Thêm bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="MISAValidateException"></exception>
        public int InsertService(MISAEntity entity)
        {
            //Validate dữ liệu:
            var isValid=Validate(entity);
            //Thực hiện thêm mới:
            if(isValid==true)
            {
                var res = _repository.Insert(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
            
        }

        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdateService(MISAEntity entity)
        {
            //Validate dữ liệu:
            var isValid = ValidateUpdate(entity);
            //Thực hiện thêm mới:
            if (isValid == true)
            {
                var res = _repository.Update(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
            
        }

        /// <summary>
        /// Thực hiện validate dữ liệu khi thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        protected virtual bool Validate(MISAEntity entity)
        {
            return true;
        }
        /// <summary>
        /// Thực hiện validate dữ liệu khi update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateUpdate(MISAEntity entity)
        {
            return true;
        }
        #endregion

    }
}
