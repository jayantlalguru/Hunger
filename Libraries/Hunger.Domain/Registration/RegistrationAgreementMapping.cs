using System;
using Hunger.Domain.Tracking;

namespace Hunger.Domain.Registration
{
    public class RegistrationAgreementMapping
    {                
        public int RegistrationAgreementMappingId { get; set; }
        public int RegistrationId { get; set; }
        public int AgreementId { get; set; }
        public DateTime AgreedFrom { get; set; }
        public DateTime? AgreedTill { get; set; }
        public Agreement Agreement { get; set; }
    }
}
