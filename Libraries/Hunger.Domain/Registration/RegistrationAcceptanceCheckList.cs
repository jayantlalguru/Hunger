using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.Domain.Registration
{
    public class RegistrationAcceptanceCheckList
    {   
        private static IList<string> PanCard;
        private IList<string> AddressProof;
        private IList<string> AadharCard;
        private IList<string> Photo;
        //private static IList<string> PanCard = new List<string>() { "Pan Card", "Mandatory" };
        //private IList<string> AddressProof = new List<string>() { "Address Proof", "Mandatory", "Passport, Registered House Agreement, House License" };
        //private IList<string> AadharCard = new List<string>() { "Aadhar Card", "Not Mandatory" };
        //private IList<string> Photo = new List<string>() { "Photo", "Not Mandatory" };

        private RegistrationAcceptanceCheckList()
        {
            PanCard = new List<string>() { "Pan Card", "Mandatory" };
            AddressProof = new List<string>() { "Address Proof", "Mandatory", "Passport, Registered House Agreement, House License" };
            AadharCard = new List<string>() { "Aadhar Card", "Not Mandatory" };
            Photo = new List<string>() { "Photo", "Not Mandatory" };
        }

        public static RegistrationAcceptanceCheckList AcceptanceCheckList {
            get
            {
                RegistrationAcceptanceCheckList registrationAcceptanceCheckList = new RegistrationAcceptanceCheckList();
                return registrationAcceptanceCheckList;
            }
        }        
    }    
}
