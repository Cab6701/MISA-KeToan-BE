namespace MISA.Web05.Core
{
    /// <summary>
    /// CreatedBy: THBAC (21/6/2022)
    /// </summary>
    public class Positions : BaseEntity
    {
        #region Contructor
        public Positions()
        {
            this.PositionId = Guid.NewGuid();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid PositionId { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string? PositionName { get; set; }
       
        #endregion

        #region Methods
        #endregion
    }
}
