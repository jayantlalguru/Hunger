using Hunger.Domain.Account;
using Dapper;
using Hunger.DAL.Configuration;
using System.Text;
using System.Collections.Generic;
using Hunger.DAL.Queries;
using System;

namespace Hunger.DAL.Account
{
    public class AdminLoginDAL : ConnectionProperties
    {
        /// <summary>
        /// Create an Admin user
        /// </summary>
        /// <param name="adminUser"></param>
        /// <returns></returns>
        public int CreateAdminUser(AdminUser adminUser)
        {   
            using (var dbConnection = Connection)
            {
               return dbConnection.ExecuteScalar<int>(AdminSQL.CreateAdminUser, new { adminUser.LoginId, adminUser.EmailId, adminUser.PhoneNumber, adminUser.Password, adminUser.PasswordSalt, adminUser.CurrentDate });
            }            
        }

        public Guid GetAdminPasswordSalt(string loginId)
        {
            using (var dbConnection = Connection)
            {
                return dbConnection.ExecuteScalar<Guid>(AdminSQL.AdminPasswordSalt, new { loginId });
            }
        }

        public AdminUser AdminLogin(AdminUser adminUser)
        {
            using (var dbConnection = Connection)
            {
                return (AdminUser)dbConnection.Query<AdminUser>(AdminSQL.AdminLogin, new { adminUser.LoginId, adminUser.Password, adminUser.CurrentDate });
            }            
        }
    }
}
