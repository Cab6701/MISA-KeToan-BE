namespace MISA.WEB05.DEMO.Models
{
    /// <summary>
    /// CreatedBy: THBAC (21/6/2022)
    /// </summary>
    public class Employee : BaseEntity
    {
        #region Contructor
        public Employee()
        {
            this.EmployeeId=Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Điện thoại di động
        /// </summary>
        public string? TelephoneNumber { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Số cmt
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IdentityPlace { get; set; }
        /// <summary>
        /// Lương
        /// </summary>
        public float? Salary { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string? BankAccountNumber { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string? BankProvinceName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }
        
        #endregion

        #region Methods
        #endregion
    }
}
