using System;
using Hunger.Domain.Tracking;

namespace Hunger.Domain.Account
{
    public class AdminUser : TrackingData, IUser
    {
        public int AdminUserId { get; set; }
        public string LoginId { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public override int? CreatedBy { get; set; }
        public override int? ModifiedBy { get; set; }
        public Guid PasswordSalt { get; set; }
        public int NoOfLoginAttempt { get; set; }
        public DateTime LastAccessed { get; set; }
        public int Status { get; set; }
        public Guid NewPasswordSalt
        {
            get
            {
                return Guid.NewGuid();
            }            
        } 
    }
}
