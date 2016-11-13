using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.Domain.Registration
{
    public class RegistrationRejectionReason
    {
        public string RejectionReasonText { get; set; }
        public int RegistrationId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public string SystemName { get; set; }
        public string IpAddress { get; set; }
        public int? CreatedBy { get; set; }
    }
}
