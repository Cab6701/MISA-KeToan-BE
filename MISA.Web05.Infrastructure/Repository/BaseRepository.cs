using Dapper;
using MISA.Web05.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Web05.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity>:IBaseRepository<MISAEntity>
    {
        #region Methods
        protected string ConnectionString;
        protected MySqlConnection MySqlConnection;
        protected string TableName;

        /// <summary>
        /// Author: THBAC (25/6/2022 - 15:46)
        /// Khởi tạo kết nối
        /// </summary>
        public BaseRepository()
        {
            ConnectionString = "Host=3.0.89.182; " +
                    "Port=3306; " +
                    "Database = MISA.WEB05.THBAC; " +
                    "User Id = dev; " +
                    "Password=12345678";
            TableName=typeof(MISAEntity).Name;
        }

        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:10)
        /// Hàm mẫu lấy dữ liệu
        /// </summary>
        /// <returns>Thông tin các bản ghi</returns>
        public virtual IEnumerable<MISAEntity> Get()
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"SELECT * FROM {TableName}";
                var employees = MySqlConnection.Query<MISAEntity>(sql);
                return employees;
            }
        }

        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:10)
        /// Hàm mẫu lấy dữ liệu theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Thông tin bản ghi theo ID</returns>
        public MISAEntity Get(Guid id)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @{TableName}Id";
                var parametes = new DynamicParameters();
                parametes.Add($"@{TableName}Id", id);
                var employee = MySqlConnection.QueryFirstOrDefault<MISAEntity>(sql: sql, param: parametes);
                return employee;
            }
        }

        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:15)
        /// Hàm mẫu xoá dữ liệu
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Xoá bản ghi theo ID</returns>
        public int Delete(Guid entityId)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @{TableName}Id";
                var parametes = new DynamicParameters();
                parametes.Add($"@{TableName}Id", entityId);
                var res = MySqlConnection.Execute(sql: sql, param: parametes);
                return res;
            }
        }

        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:17)
        /// Hàm mẫu thêm dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Thêm bản ghi</returns>
        public int Insert(MISAEntity entity)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Insert{TableName}";
                var res = MySqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }

        /// <summary>
        /// Author: THBAC (25/6/2022 - 22:20)
        /// Hàm mẫu sửa dữ liệu
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Cập nhật bản ghi</returns>
        public int Update(MISAEntity entity)
        {
            using (MySqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_Update{TableName}";
                var res = MySqlConnection.Execute(sql: sql, param: entity, commandType: System.Data.CommandType.StoredProcedure);
                return res;
            }
        }
        #endregion
    }
}
