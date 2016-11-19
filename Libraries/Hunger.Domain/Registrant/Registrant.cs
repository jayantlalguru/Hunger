using System;
using Hunger.Domain.Tracking;

namespace Hunger.Domain.Registrant
{
    public class Registrant : TrackingData
    {
        public int RegistrantId { get; set; }
        public int RegistrationId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public Guid? PasswordSalt2 { get; set; }
        public Guid? PasswordSalt3 { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LastAccessed { get; set; }
        public byte? NoOfLoginAttempt { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string SystemName { get; set; }
        public string IpAddress { get; set; }
        public int Status { get; set; }
        public Guid NewPasswordSalt
        {
            get
            {
                return Guid.NewGuid();
            }
        }
        public override int? CreatedBy { get; set; }
        public override int? ModifiedBy { get; set; }
    }
}
