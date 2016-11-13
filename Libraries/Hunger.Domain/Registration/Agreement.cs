using System;
using Hunger.Domain.Tracking;

namespace Hunger.Domain.Registration
{
    public class Agreement : TrackingData
    {   
        public int AgreementId { get; set; }
        public string AgreementText { get; set; }        
        public bool? IsAgreementValid { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
        public override int? CreatedBy { get; set; }
        public override int? ModifiedBy { get; set; }
        public int MaxRejectionLimit { get; set; }
    }
}
