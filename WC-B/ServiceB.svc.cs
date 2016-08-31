using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WC_B
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IServiceB
    {
        public string GetData(int value)
        {
            try
            {
                var client = new ServiceReferenceA.ServiceAClient();
                client.ClientCredentials.Windows.ClientCredential.Domain = "yuray2";
                client.ClientCredentials.Windows.ClientCredential.UserName = "adamus";
                client.ClientCredentials.Windows.ClientCredential.Password = "Internet=01!";
                client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                return client.GetData(10);
            }
            catch (Exception ex)
            {
                return string.Format(ex.Message);
            }
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
