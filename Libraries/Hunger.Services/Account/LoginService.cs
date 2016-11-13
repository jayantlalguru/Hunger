using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hunger.Domain.Account;
using Hunger.DAL.Account;

namespace Hunger.Services.Account
{
    public class LoginService
    {
        public int CreateAdminUser(AdminUser adminUser)
        {
            LoginDAL loginDAL = new LoginDAL();
            return loginDAL.CreateAdminUser(adminUser);            
        }

        public AdminUser AdminLogin(AdminUser adminUser)
        {
            LoginDAL loginDAL = new LoginDAL();
            return loginDAL.AdminLogin(adminUser);            
        }

        public Guid GetPasswordSalt(string loginId)
        {
            LoginDAL loginDAL = new LoginDAL();
            return loginDAL.GetAdminPasswordSalt(loginId);
        }
    }
}
