using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.Rest.Utilities
{
    public static class Status
    {
        public static string LoginMessage(int status)
        {
            switch(status)
            {
                case 1:
                    return Messages.LoginSuccess;
                    break;
                case -2:
                    return Messages.EmailIdExists;
                    break;
                case -3:
                    return Messages.LoginIdExists;
                    break;                
                case -4:
                    return Messages.InvalidIdOrPwd;
                    break;
                case -5:
                    return Messages.UserDisabled;
                    break;
                default:
                    return "No Status";
            }
        }
    }
}
