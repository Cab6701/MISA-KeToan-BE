using MISA.Web05.Core.Exceptions;
using MISA.Web05.Core.Interfaces.Repository;
using MISA.Web05.Core.Interfaces.Services;
using MISA.Web05.Core.Services;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.Web05.Core
{
    public class EmployeeService :BaseService<Employee>, IEmployeeService
    {
        #region Constructor
        IEmployeeRepository _repository;


        /// <summary>
        /// Author: THBAC (21/6/2022 - 22:02)
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="repository"></param>
        public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Author: THBAC (25/6/2022 - 15:23)
        /// Validate dữ liệu khi thêm dữ liệu
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>false-là không hợp lệ, true-hợp lệ</returns>

        protected override bool Validate(Employee employee)
        {
            
            //Check bắt buộc nhập mã nhân viên:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                IsValid=false;
                ErrorValidateMsgs.Add("Mã nhân viên không được phép để trống");
            }
            //Check bắt buộc nhập tên nhân viên:
            if (string.IsNullOrEmpty(employee.FullName))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên nhân viên không được phép để trống");
            }
            //Check bắt buộc nhập phòng ban:
            if (string.IsNullOrEmpty(employee.DepartmentId.ToString()))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên phòng ban không được phép để trống");
            }
            //Check trùng mã:
            if (_repository.CheckEmployeeCodeExits(employee.EmployeeCode) == true)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã nhân viên đã tồn tại");
            }
            //Validate ngày chọn không được lớn hơn ngày hiện tại
            if (!string.IsNullOrEmpty(employee.DateOfBirth?.ToString()) && employee.DateOfBirth > DateTime.Now)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Ngày sinh không được phép lớn hơn ngày hiện tại");
            }
            //Validate ngày chọn không được lớn hơn ngày hiện tại
            if (!string.IsNullOrEmpty(employee.IdentityDate?.ToString()) &&  employee.IdentityDate > DateTime.Now)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Ngày cấp không được phép lớn hơn ngày hiện tại");
            }
            //Check email
            if (!string.IsNullOrEmpty(employee.Email) && !Regex.IsMatch(employee.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Email không đúng định dạng");
            }


            return IsValid;
        }
        /// <summary>
        /// Author: THBAC (25/6/2022 - 15:23)
        /// Validate dữ liệu khi sửa dữ liệu
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>false-là không hợp lệ, true-hợp lệ</returns>
        protected override bool ValidateUpdate(Employee employee)
        {
            //Check bắt buộc nhập code:
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Mã nhân viên không được phép để trống");
            }
            //Check bắt buộc nhập tên nhân viên:
            if (string.IsNullOrEmpty(employee.FullName))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên nhân viên không được phép để trống");
            }
            //Check bắt buộc nhập phòng ban:
            if (string.IsNullOrEmpty(employee.DepartmentId.ToString()))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Tên phòng ban không được phép để trống");
            }
            //Validate ngày chọn không được lớn hơn ngày hiện tại
            if (!string.IsNullOrEmpty(employee.DateOfBirth?.ToString()) && employee.DateOfBirth > DateTime.Now)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Ngày sinh không được phép lớn hơn ngày hiện tại");
            }
            //Validate ngày chọn không được lớn hơn ngày hiện tại
            if (!string.IsNullOrEmpty(employee.IdentityDate?.ToString()) && employee.IdentityDate > DateTime.Now)
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Ngày cấp không được phép lớn hơn ngày hiện tại");
            }
            //Check email
            if (!string.IsNullOrEmpty(employee.Email) && !Regex.IsMatch(employee.Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"))
            {
                IsValid = false;
                ErrorValidateMsgs.Add("Email không đúng định dạng");
            }

            return IsValid;
        }

        /// <summary>
        /// Author: THBAC (26/7/2022)
        /// Định dạng giới tính
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> Trả về tên giới tính kiểu string</returns>
        private string formatGender(int? gender)
        {
            if (gender == 0) return "Nam";
            if (gender == 1) return "Nữ";
            else return "Khác";
        }

        /// <summary>
        /// Author: THBAC (24/7/2022)
        /// Thiết lật giá trị cho các ô Excel
        /// </summary>
        /// <param name="cell">Ô dữ liệu</param>
        /// <param name="value">Giá trị</param>

        private void SetCell(ExcelRange cell, string? value)
        {
            // Set border
            var border = cell.Style.Border;
            border.Bottom.Style =
                border.Top.Style =
                border.Left.Style =
                border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

            // Set font name
            cell.Style.Font.Name = "Times New Roman";

            // Set font size
            cell.Style.Font.Size = 11;

            // Set value
            cell.Value = value;
        }
        /// <summary>
        /// Author: THBAC (25/7/2022)
        /// Căn giữa dữ liệu
        /// </summary>
        /// <param name="cell">Ô dữ liệu</param>
        /// <param name="value">Giá trị</param>
        private void SetCellCenter(ExcelRange cell, string? value)
        {
            SetCell(cell, value);
            // căn giữa
            cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        }
        /// <summary>
        /// Author: THBAC (24/7/2022)
        /// Xuấ file Excel
        /// </summary>
        /// <returns></returns>
        public ExcelPackage Export()
        {
            List<Employee> empList = new List<Employee>();
            
            empList = _repository.Get().ToList();
           

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Danh sách nhân viên");

            if (empList == null || !empList.Any()) return pck;
           

            ws.Cells.Style.Font.Name = "Arial";
            ws.Cells[1, 1].Value = "Danh sách nhân viên";
            ws.Cells[1, 1, 1, 9].Merge = true;
            ws.Cells[1, 1, 1, 9].Style.Font.Size = 16;
            ws.Cells[1, 1, 1, 9].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, 9].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            // mảng các tên cột
            string[] heads = { "STT", "Mã nhân viên", "Tên nhân viên", "Giới tính", "Ngày sinh", "Chức danh", "Đơn vị", "Số tài khoản", "Tên ngân hàng" };

            // chỉ số cột hiện tại
            int colIndex = 1;
            foreach (var item in heads)
            {
                var cell = ws.Cells[3, colIndex];
                // Set màu thành gray
                var fill = cell.Style.Fill;
                fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                // Căn chỉnh border
                var border = cell.Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                // Font bold
                cell.Style.Font.Bold = true;
                // Font size
                cell.Style.Font.Size = 10;
                // Text center
                cell.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                // set value
                cell.Value = item;

                colIndex++;
            }

            // hàng bắt đầu ghi dữ liệu
            int rowStart = 4;

            // số thứ tự
            int index = 1;
            foreach (var item in empList)
            {
                SetCell(ws.Cells[string.Format("A{0}", rowStart)], index.ToString());
                SetCell(ws.Cells[string.Format("B{0}", rowStart)], item.EmployeeCode);
                SetCell(ws.Cells[string.Format("C{0}", rowStart)], item.FullName);
                SetCell(ws.Cells[string.Format("D{0}", rowStart)], formatGender(item.Gender));
                SetCellCenter(ws.Cells[string.Format("E{0}", rowStart)], string.Format("{0:dd/MM/yyyy}", item.DateOfBirth));
                SetCell(ws.Cells[string.Format("F{0}", rowStart)], item.PositionName);
                SetCell(ws.Cells[string.Format("G{0}", rowStart)], item.DepartmentName);
                SetCell(ws.Cells[string.Format("H{0}", rowStart)], item.BankAccountNumber);
                SetCell(ws.Cells[string.Format("I{0}", rowStart)], item.BankName);
                index++;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            return pck;
        }
        #endregion
    }
}
