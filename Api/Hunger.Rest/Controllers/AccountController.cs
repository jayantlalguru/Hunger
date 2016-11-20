using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hunger.Services.Account;
using Hunger.Domain.Account;
using Hunger.Rest.Utilities;
using Hunger.Domain.Registration;

namespace Hunger.Rest.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAdminLoginService _adminLoginService;
        private AdminUser _adminUser;
        public AccountController(IAdminLoginService adminLoginService, AdminUser adminUser)
        {
            _adminLoginService = adminLoginService;
            _adminUser = adminUser;
        }       
        // GET: api/Account
        public string Get()
        {   
            _adminUser.LoginId = "jayant";
            _adminUser.PasswordSalt = _adminLoginService.GetPasswordSalt(_adminUser.LoginId);
            if(_adminUser.PasswordSalt == null || _adminUser.PasswordSalt == Guid.Empty)
            {
                return Messages.InvalidIdOrPwd;
            }
            _adminUser.Password = "passwor";
            _adminUser.Password = Security.Sha512Encryption(_adminUser.Password, _adminUser.PasswordSalt);
            var adminUsers = _adminLoginService.AdminLogin(_adminUser);
            return Status.LoginMessage(adminUsers.First().Status);
        }

        // GET: api/Account/5
        public string Get(int id)
        {            
            AdminLoginService loginService = new AdminLoginService();
            AdminUser adminUser = new AdminUser();
            adminUser.LoginId = "reyaansh";
            adminUser.IsActive = true;
            adminUser.PhoneNumber = "+91-8898308676";
            adminUser.EmailId = "reyaansh@outlook.com";
            adminUser.PasswordSalt = adminUser.NewPasswordSalt;
            adminUser.Password = Security.Sha512Encryption("password", adminUser.PasswordSalt);
            int status = loginService.CreateAdminUser(adminUser);
            return Status.LoginMessage(status);
        }
    }
}
