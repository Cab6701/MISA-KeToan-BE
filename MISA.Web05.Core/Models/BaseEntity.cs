namespace MISA.Web05.Core
{ 
    public class BaseEntity
    {
        #region Properties
        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Author: THBAC (20/6/2022 - 21:02)
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
        #endregion
    }
}
