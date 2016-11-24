using System;
using System.Collections.Generic;
using Hunger.Domain.Account;
using Hunger.DAL.Account;
using Hunger.Services.Account.Interfaces;

namespace Hunger.Services.Account
{
    public class AdminLoginService : IAdminLoginService
    {
        public int CreateAdminUser(AdminUser adminUser)
        {
            AdminLoginDAL loginDAL = new AdminLoginDAL();
            return loginDAL.CreateAdminUser(adminUser);            
        }

        public IEnumerable<AdminUser> AdminLogin(AdminUser adminUser)
        {
            AdminLoginDAL loginDAL = new AdminLoginDAL();
            return loginDAL.AdminLogin(adminUser);            
        }

        public Guid GetPasswordSalt(string loginId)
        {
            AdminLoginDAL loginDAL = new AdminLoginDAL();
            return loginDAL.GetAdminPasswordSalt(loginId);
        }
    }
}
