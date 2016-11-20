using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunger.Domain.Account;
using Hunger.DAL.Account;

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
