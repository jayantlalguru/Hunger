using Hunger.Domain.Tracking;
using System;
using System.Collections.Generic;

namespace Hunger.Domain.Registration
{
    public class Registration : TrackingData
    {   
        public int RegistrationId { get; set; }
        public string Name { get; set; }
        public string RegisteredPhoneNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public int AgreementId { get; set; }
        public bool HasAgreedToTermsAndCondition { get; set; }
        public bool? IsRegistrationAccepted { get; set; }
        public bool? IsRejected { get; set; }
        public int? NoOfTimeRejected { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public override int? ModifiedBy { get; set; }
        public override int? CreatedBy { get; set; }
        public DateTime AgreementAcceptedOn { get; set; }
        public Agreement Agreement { get; set; }        
        public IEnumerable<RegistrationAgreementMapping> RegistrationAgreementMappings { get; set; }
    }
}
