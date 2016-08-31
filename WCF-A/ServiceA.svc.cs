using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_A
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceA : IServiceA
    {
        [OperationBehavior(Impersonation = ImpersonationOption.Allowed)]
        public string GetData(int value)
        {
            try{
                var myIdentity = ServiceSecurityContext.Current.WindowsIdentity;

                using (myIdentity.Impersonate())
                {
                    var client = new WCF_A.ServiceReferenceSonic.Service1Client();
                    var strContext = string.Format("Username(A): {0} \nImpernationLeve(A): {1} \nAuthenticationType(A): {2} \n=======\n", myIdentity.Name.ToString(), myIdentity.ImpersonationLevel.ToString(), myIdentity.AuthenticationType.ToString());
                    client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Delegation;
                    return strContext + client.GetData(10);
                }
            }
            catch(Exception e)
            {
                return e.Message;
            }
            
        }

    }
}
