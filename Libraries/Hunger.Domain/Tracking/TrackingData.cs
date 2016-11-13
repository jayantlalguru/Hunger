using System;
using System.Linq;
using System.Net;

namespace Hunger.Domain.Tracking
{
    public abstract class TrackingData
    {
        public DateTime CurrentDate
        {
            get
            {
                return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }            
        }

        public DateTime? CurrentModificationDate
        {
            get
            {
                return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }            
        }
        
        public string CurrentIpAddress
        {
            get
            {
                return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();                
            }            
        }

        public string CurrentSystemName
        {
            get
            {
                return Dns.GetHostName();
            }            
        }

        public abstract int? CreatedBy { get; set; }
        public abstract int? ModifiedBy { get; set; }
    }
}
