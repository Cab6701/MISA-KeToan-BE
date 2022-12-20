namespace MISA.Web05.Core
{
    //Phòng ban
    //CreatedBy: THBAC
    public class Department:BaseEntity
    {
        #region Constructor
        public Department()
        {
            this.DepartmentId = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        #endregion


        #region Methods
        #endregion

    }
}
