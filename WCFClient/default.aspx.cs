using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WCFClient.WCFServerSonic;

namespace WCFClient
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WCFServerSonic.Service1Client client = new Service1Client())
            {
                client.ClientCredentials.Windows.ClientCredential.Domain = "yuray2";
                client.ClientCredentials.Windows.ClientCredential.UserName = "adamus";
                client.ClientCredentials.Windows.ClientCredential.Password = "Internet=01!";
                client.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Delegation;
                this.Label1.Text = client.GetData(10);
            }
        }
    }
}